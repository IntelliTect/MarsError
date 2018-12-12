/// <reference path="coalesce.dependencies.d.ts" />

module MarsError {
    class SearchViewModel {

        public fooSearch = new ListViewModels.ThingList();

        constructor() {
            this.fooSearch.pageSize(10);
            this.fooSearch.dataSource = new this.fooSearch.dataSources.FooSearchDataSource();
            this.fooSearch.isLoaded(true);

        }

        public reset = () => {
            $(':input').val('');
            this.fooSearch.items(null);
            this.fooSearch.totalCount(null);
        }

        public search = () => {
            this.fooSearch.load();
        }

    }

    var vm = new SearchViewModel();

    $(() => {
        $(':input').keypress(e => {
            if (e.keyCode === 13) {
                vm.search();
            }
        });
        ko.applyBindings(vm);
    });

}