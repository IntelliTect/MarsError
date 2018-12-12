
/// <reference path="../coalesce.dependencies.d.ts" />

// Generated by IntelliTect.Coalesce

module ListViewModels {
    
    export namespace ChildDataSources {
        export class Default extends Coalesce.DataSource<ViewModels.Child> { }
    }
    
    export class ChildList extends Coalesce.BaseListViewModel<ViewModels.Child> {
        public readonly modelName: string = "Child";
        public readonly apiController: string = "/Child";
        public modelKeyName: string = "childId";
        public itemClass: new () => ViewModels.Child = ViewModels.Child;
        
        public filter: {
            childId?: string;
            name?: string;
            parentId?: string;
        } | null = null;
        
        /** The namespace containing all possible values of this.dataSource. */
        public dataSources: typeof ChildDataSources = ChildDataSources;
        
        /** The data source on the server to use when retrieving objects. Valid values are in this.dataSources. */
        public dataSource: Coalesce.DataSource<ViewModels.Child> = new this.dataSources.Default();
        
        /** Configuration for all instances of ChildList. Can be overidden on each instance via instance.coalesceConfig. */
        public static coalesceConfig = new Coalesce.ListViewModelConfiguration<ChildList, ViewModels.Child>(Coalesce.GlobalConfiguration.listViewModel);
        
        /** Configuration for this ChildList instance. */
        public coalesceConfig: Coalesce.ListViewModelConfiguration<ChildList, ViewModels.Child>
            = new Coalesce.ListViewModelConfiguration<ChildList, ViewModels.Child>(ChildList.coalesceConfig);
        
        
        protected createItem = (newItem?: any, parent?: any) => new ViewModels.Child(newItem, parent);
        
        constructor() {
            super();
        }
    }
}