﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cofoundry.Domain.Data;
using Cofoundry.Domain.CQS;
using System.Data.Entity;

namespace Cofoundry.Domain
{
    public class GetCustomEntityEntityMicroSummariesByIdRangeQueryHandler
        : IQueryHandler<GetCustomEntityEntityMicroSummariesByIdRangeQuery, IDictionary<int, RootEntityMicroSummary>>
        , IAsyncQueryHandler<GetCustomEntityEntityMicroSummariesByIdRangeQuery, IDictionary<int, RootEntityMicroSummary>>
        , IIgnorePermissionCheckHandler
    {
        #region constructor

        private readonly CofoundryDbContext _dbContext;
        private readonly IPermissionValidationService _permissionValidationService;

        public GetCustomEntityEntityMicroSummariesByIdRangeQueryHandler(
            CofoundryDbContext dbContext,
            IPermissionValidationService permissionValidationService
            )
        {
            _dbContext = dbContext;
            _permissionValidationService = permissionValidationService;
        }

        #endregion

        #region execution

        public async Task<IDictionary<int, RootEntityMicroSummary>> ExecuteAsync(GetCustomEntityEntityMicroSummariesByIdRangeQuery query, IExecutionContext executionContext)
        {
            var results = await Query(query).ToDictionaryAsync(e => e.RootEntityId);
            EnforcePermissions(results, executionContext);

            return results;
        }

        public IDictionary<int, RootEntityMicroSummary> Execute(GetCustomEntityEntityMicroSummariesByIdRangeQuery query, IExecutionContext executionContext)
        {
            var results = Query(query).ToDictionary(e => e.RootEntityId);
            EnforcePermissions(results, executionContext);

            return results;
        }

        #endregion

        #region private helpers

        private IQueryable<RootEntityMicroSummary> Query(GetCustomEntityEntityMicroSummariesByIdRangeQuery query)
        {
            var dbQuery = _dbContext
                .CustomEntityVersions
                .AsNoTracking()
                .FilterByActiveLocales()
                .FilterByWorkFlowStatusQuery(WorkFlowStatusQuery.Latest)
                .Where(v => query.CustomEntityIds.Contains(v.CustomEntityId))
                .Select(v => new RootEntityMicroSummary()
                {
                    RootEntityId = v.CustomEntityId,
                    RootEntityTitle = v.Title,
                    EntityDefinitionName = v.CustomEntity.CustomEntityDefinition.EntityDefinition.Name,
                    EntityDefinitionCode = v.CustomEntity.CustomEntityDefinition.CustomEntityDefinitionCode
                });

            return dbQuery;
        }

        private void EnforcePermissions(IDictionary<int, RootEntityMicroSummary> entities, IExecutionContext executionContext)
        {
            var definitionCodes = entities.Select(e => e.Value.EntityDefinitionCode);

            _permissionValidationService.EnforceCustomEntityPermission<CustomEntityReadPermission>(definitionCodes, executionContext.UserContext);

        }

        #endregion
    }
}
