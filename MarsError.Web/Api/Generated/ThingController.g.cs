
using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Api;
using IntelliTect.Coalesce.Api.Controllers;
using IntelliTect.Coalesce.Api.DataSources;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Mapping.IncludeTrees;
using IntelliTect.Coalesce.Models;
using IntelliTect.Coalesce.TypeDefinition;
using MarsError.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MarsError.Web.Api
{
    [Route("api/Thing")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class ThingController
        : BaseApiController<MarsError.Data.Models.Thing, ThingDtoGen, MarsError.Data.AppDbContext>
    {
        public ThingController(MarsError.Data.AppDbContext db) : base(db)
        {
            GeneratedForClassViewModel = ReflectionRepository.Global.GetClassViewModel<MarsError.Data.Models.Thing>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<ThingDtoGen>> Get(
            long id,
            DataSourceParameters parameters,
            IDataSource<MarsError.Data.Models.Thing> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<ThingDtoGen>> List(
            ListParameters parameters,
            IDataSource<MarsError.Data.Models.Thing> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<MarsError.Data.Models.Thing> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<ThingDtoGen>> Save(
            ThingDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<MarsError.Data.Models.Thing> dataSource,
            IBehaviors<MarsError.Data.Models.Thing> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<ThingDtoGen>> Delete(
            long id,
            IBehaviors<MarsError.Data.Models.Thing> behaviors,
            IDataSource<MarsError.Data.Models.Thing> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);

        /// <summary>
        /// Downloads CSV of ThingDtoGen
        /// </summary>
        [HttpGet("csvDownload")]
        [Authorize]
        public virtual Task<FileResult> CsvDownload(
            ListParameters parameters,
            IDataSource<MarsError.Data.Models.Thing> dataSource)
            => CsvDownloadImplementation(parameters, dataSource);

        /// <summary>
        /// Returns CSV text of ThingDtoGen
        /// </summary>
        [HttpGet("csvText")]
        [Authorize]
        public virtual Task<string> CsvText(
            ListParameters parameters,
            IDataSource<MarsError.Data.Models.Thing> dataSource)
            => CsvTextImplementation(parameters, dataSource);

        /// <summary>
        /// Saves CSV data as an uploaded file
        /// </summary>
        [HttpPost("csvUpload")]
        [Authorize]
        public virtual Task<IEnumerable<ItemResult>> CsvUpload(
            IFormFile file,
            IDataSource<MarsError.Data.Models.Thing> dataSource,
            IBehaviors<MarsError.Data.Models.Thing> behaviors,
            bool hasHeader = true)
            => CsvUploadImplementation(file, dataSource, behaviors, hasHeader);

        /// <summary>
        /// Saves CSV data as a posted string
        /// </summary>
        [HttpPost("csvSave")]
        [Authorize]
        public virtual Task<IEnumerable<ItemResult>> CsvSave(
            string csv,
            IDataSource<MarsError.Data.Models.Thing> dataSource,
            IBehaviors<MarsError.Data.Models.Thing> behaviors,
            bool hasHeader = true)
            => CsvSaveImplementation(csv, dataSource, behaviors, hasHeader);

        // Methods from data class exposed through API Controller.
    }
}
