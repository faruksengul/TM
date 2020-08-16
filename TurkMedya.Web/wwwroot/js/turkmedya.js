var page_url = {
    "TurkMedya_List": "/TurkMedya/List",
    "TurkMedya_Detail": "/TurkMedya/Detail"
};
var staticCategories = { "": { "categoryId": "-1", "title": "Tümü", "slug": "tümü", "color": null }, "magazin": { "categoryId": "6", "title": "MAGAZ�N", "slug": "magazin", "color": null }, "guncel": { "categoryId": "7", "title": "G�NCEL", "slug": "guncel", "color": null }, "spor": { "categoryId": "4", "title": "SPOR", "slug": "spor", "color": null }, "ekonomi": { "categoryId": "3", "title": "EKONOM�", "slug": "ekonomi", "color": null }, "yasam": { "categoryId": "5", "title": "YA�AM", "slug": "yasam", "color": null }, "kultur-sanat": { "categoryId": "12", "title": "K�LT�R-SANAT", "slug": "kultur-sanat", "color": null }, "teknoloji": { "categoryId": "8", "title": "TEKNOLOJ�", "slug": "teknoloji", "color": null }, "dunya": { "categoryId": "14", "title": "D�NYA", "slug": "dunya", "color": null }, "siyaset": { "categoryId": "2", "title": "S�YASET", "slug": "siyaset", "color": null } };

angular.module("TurkMedyaApp", [])
    .controller("TurkMedyaCtrl", function ($scope, $http) {
        $scope.StaticCategories = staticCategories;
        $scope.ListResult = {};
        $scope.FirstLoad = function () {
            var category, pageNumber, itemId;
            var query = location.hash.replace("#?", "").split("&");
            query.forEach(q => {
                if (q.startsWith("category="))
                    category = q.replace("category=", "");
                if (q.startsWith("pageNumber="))
                    pageNumber = q.replace("pageNumber=", "");
                if (q.startsWith("itemId="))
                    itemId = q.replace("itemId=", "");
            });
            if (!itemId)
                $scope.LoadList(pageNumber, category);
            if (itemId)
                $scope.ShowDetail(itemId);
        }
        $scope.LoadList = function (pageNumber, category, searchStr) {
            location.href = "#?searchString=" + searchStr + "&category=" + (category || "") + "&pageNumber=" + (pageNumber || "");
            $http.get(page_url.TurkMedya_List, { params: { Category: category, PageNumber: pageNumber, SearchString: searchStr } }).then((res) => {
                $scope.ListResult = res.data;
                //PageList
                $scope.ListResult.Pages = [];
                for (var i = 1; i < res.data.pageCount; i++) {
                    $scope.ListResult.Pages.push(i);
                }
            });
        }
        $scope.Detail = null;
        $scope.BackList = function () {
            $scope.Detail = null;
            $scope.LoadList($scope.ListResult.pageNumber, $scope.ListResult.category, $scope.ListResult.searchString);
        }
        $scope.ShowDetail = function (itemId) {
            location.href = "#?itemId=" + itemId;
            $http.get(page_url.TurkMedya_Detail, { params: { itemId: itemId } }).then((res) => {
                $scope.Detail = res.data.data;
            });
        }
    })
    .directive('myEnter', function () {
        return function (scope, element, attrs) {
            element.bind("keydown keypress", function (event) {
                if (event.which === 13) {
                    scope.$apply(function () {
                        scope.$eval(attrs.myEnter);
                    });

                    event.preventDefault();
                }
            });
        };
    });