
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
    [Route("api/Child")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class ChildController
        : BaseApiController<MarsError.Data.Models.Child, ChildDtoGen, MarsError.Data.AppDbContext>
    {
        public ChildController(MarsError.Data.AppDbContext db) : base(db)
        {
            GeneratedForClassViewModel = ReflectionRepository.Global.GetClassViewModel<MarsError.Data.Models.Child>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<ChildDtoGen>> Get(
            long id,
            DataSourceParameters parameters,
            IDataSource<MarsError.Data.Models.Child> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<ChildDtoGen>> List(
            ListParameters parameters,
            IDataSource<MarsError.Data.Models.Child> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<MarsError.Data.Models.Child> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<ChildDtoGen>> Save(
            ChildDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<MarsError.Data.Models.Child> dataSource,
            IBehaviors<MarsError.Data.Models.Child> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<ChildDtoGen>> Delete(
            long id,
            IBehaviors<MarsError.Data.Models.Child> behaviors,
            IDataSource<MarsError.Data.Models.Child> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);

        /// <summary>
        /// Downloads CSV of ChildDtoGen
        /// </summary>
        [HttpGet("csvDownload")]
        [Authorize]
        public virtual Task<FileResult> CsvDownload(
            ListParameters parameters,
            IDataSource<MarsError.Data.Models.Child> dataSource)
            => CsvDownloadImplementation(parameters, dataSource);

        /// <summary>
        /// Returns CSV text of ChildDtoGen
        /// </summary>
        [HttpGet("csvText")]
        [Authorize]
        public virtual Task<string> CsvText(
            ListParameters parameters,
            IDataSource<MarsError.Data.Models.Child> dataSource)
            => CsvTextImplementation(parameters, dataSource);

        /// <summary>
        /// Saves CSV data as an uploaded file
        /// </summary>
        [HttpPost("csvUpload")]
        [Authorize]
        public virtual Task<IEnumerable<ItemResult>> CsvUpload(
            IFormFile file,
            IDataSource<MarsError.Data.Models.Child> dataSource,
            IBehaviors<MarsError.Data.Models.Child> behaviors,
            bool hasHeader = true)
            => CsvUploadImplementation(file, dataSource, behaviors, hasHeader);

        /// <summary>
        /// Saves CSV data as a posted string
        /// </summary>
        [HttpPost("csvSave")]
        [Authorize]
        public virtual Task<IEnumerable<ItemResult>> CsvSave(
            string csv,
            IDataSource<MarsError.Data.Models.Child> dataSource,
            IBehaviors<MarsError.Data.Models.Child> behaviors,
            bool hasHeader = true)
            => CsvSaveImplementation(csv, dataSource, behaviors, hasHeader);

        // Methods from data class exposed through API Controller.
    }
}
