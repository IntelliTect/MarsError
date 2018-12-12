
/// <reference path="../coalesce.dependencies.d.ts" />

// Generated by IntelliTect.Coalesce

module ViewModels {
    
    export class Thing extends Coalesce.BaseViewModel {
        public readonly modelName = "Thing";
        public readonly primaryKeyName = "thingId";
        public readonly modelDisplayName = "Thing";
        public readonly apiController = "/Thing";
        public readonly viewController = "/Thing";
        
        /** Configuration for all instances of Thing. Can be overidden on each instance via instance.coalesceConfig. */
        public static coalesceConfig: Coalesce.ViewModelConfiguration<Thing>
            = new Coalesce.ViewModelConfiguration<Thing>(Coalesce.GlobalConfiguration.viewModel);
        
        /** Configuration for the current Thing instance. */
        public coalesceConfig: Coalesce.ViewModelConfiguration<this>
            = new Coalesce.ViewModelConfiguration<Thing>(Thing.coalesceConfig);
        
        /** The namespace containing all possible values of this.dataSource. */
        public dataSources: typeof ListViewModels.ThingDataSources = ListViewModels.ThingDataSources;
        
        
        public thingId: KnockoutObservable<number | null> = ko.observable(null);
        public foo: KnockoutObservable<string | null> = ko.observable(null);
        public bar: KnockoutObservable<string | null> = ko.observable(null);
        public children: KnockoutObservableArray<ViewModels.Child> = ko.observableArray([]);
        
        
        
        /** Add object to children */
        public addToChildren = (autoSave?: boolean | null): Child => {
            var newItem = new Child();
            if (typeof(autoSave) == 'boolean'){
                newItem.coalesceConfig.autoSaveEnabled(autoSave);
            }
            newItem.parent = this;
            newItem.parentCollection = this.children;
            newItem.isExpanded(true);
            newItem.parentId(this.thingId());
            this.children.push(newItem);
            return newItem;
        };
        
        /** ListViewModel for Children. Allows for loading subsets of data. */
        public childrenList: (loadImmediate?: boolean) => ListViewModels.ChildList;
        
        
        /** Url for a table view of all members of collection Children for the current object. */
        public childrenListUrl: KnockoutComputed<string> = ko.computed(
            () => this.coalesceConfig.baseViewUrl() + '/Child/Table?filter.parentId=' + this.thingId(),
            null, { deferEvaluation: true }
        );
        
        
        
        
        /** 
            Load the ViewModel object from the DTO.
            @param data: The incoming data object to load.
            @param force: Will override the check against isLoading that is done to prevent recursion. False is default.
            @param allowCollectionDeletes: Set true when entire collections are loaded. True is the default. 
            In some cases only a partial collection is returned, set to false to only add/update collections.
        */
        public loadFromDto = (data: any, force: boolean = false, allowCollectionDeletes: boolean = true): void => {
            if (!data || (!force && this.isLoading())) return;
            this.isLoading(true);
            // Set the ID 
            this.myId = data.thingId;
            this.thingId(data.thingId);
            // Load the lists of other objects
            if (data.children != null) {
                // Merge the incoming array
                Coalesce.KnockoutUtilities.RebuildArray(this.children, data.children, 'childId', Child, this, allowCollectionDeletes);
            }
            
            // The rest of the objects are loaded now.
            this.foo(data.foo);
            this.bar(data.bar);
            if (this.coalesceConfig.onLoadFromDto()){
                this.coalesceConfig.onLoadFromDto()(this as any);
            }
            this.isLoading(false);
            this.isDirty(false);
            if (this.coalesceConfig.validateOnLoadFromDto()) this.validate();
        };
        
        /** Saves this object into a data transfer object to send to the server. */
        public saveToDto = (): any => {
            var dto: any = {};
            dto.thingId = this.thingId();
            
            dto.foo = this.foo();
            dto.bar = this.bar();
            
            return dto;
        }
        
        /** 
            Loads any child objects that have an ID set, but not the full object.
            This is useful when creating an object that has a parent object and the ID is set on the new child.
        */
        public loadChildren = (callback?: () => void): void => {
            var loadingCount = 0;
            if (loadingCount == 0 && typeof(callback) == "function") { callback(); }
        };
        
        public setupValidation(): void {
            if (this.errors !== null) return;
            this.errors = ko.validation.group([
            ]);
            this.warnings = ko.validation.group([
            ]);
        }
        
        constructor(newItem?: object, parent?: Coalesce.BaseViewModel | ListViewModels.ThingList) {
            super(parent);
            this.baseInitialize();
            const self = this;
            
            
            
            // List Object model for Children. Allows for loading subsets of data.
            var _childrenList: ListViewModels.ChildList;
            this.childrenList = function(loadImmediate = true) {
                if (!_childrenList) {
                    _childrenList = new ListViewModels.ChildList();
                    if (loadImmediate) loadChildrenList();
                    self.thingId.subscribe(loadChildrenList)
                }
                return _childrenList;
            }
            function loadChildrenList() {
                if (self.thingId()) {
                    _childrenList.queryString = "filter.ParentId=" + self.thingId();
                    _childrenList.load();
                }
            }
            
            
            
            self.foo.subscribe(self.autoSave);
            self.bar.subscribe(self.autoSave);
            
            if (newItem) {
                self.loadFromDto(newItem, true);
            }
        }
    }
    
    export namespace Thing {
    }
}
