using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Claims;

namespace MarsError.Web.Models
{
    public partial class ChildDtoGen : GeneratedDto<MarsError.Data.Models.Child>
    {
        public ChildDtoGen() { }

        public long? ChildId { get; set; }
        public string Name { get; set; }
        public MarsError.Web.Models.ThingDtoGen Parent { get; set; }
        public long? ParentId { get; set; }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(MarsError.Data.Models.Child obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            // Fill the properties of the object.

            this.ChildId = obj.ChildId;
            this.Name = obj.Name;
            this.ParentId = obj.ParentId;
            if (tree == null || tree[nameof(this.Parent)] != null)
                this.Parent = obj.Parent.MapToDto<MarsError.Data.Models.Thing, ThingDtoGen>(context, tree?[nameof(this.Parent)]);

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(MarsError.Data.Models.Child entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            entity.ChildId = (ChildId ?? entity.ChildId);
            entity.Name = Name;
            entity.ParentId = (ParentId ?? entity.ParentId);
        }
    }
}
