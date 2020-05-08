function slugFunc() {

    this.ajaxUrl = null;

    this.init = function (ajaxUrl) {
        this.ajaxUrl = ajaxUrl;
    };

    this.run = function (sourceSelector, targetSelector, refreshSelector) {
        this.generateSlug = function () {
            var title = $(sourceSelector).val();
            if (!title) return;

            $.post(this.ajaxUrl, { title: title }, function (data) {
                $(targetSelector).val(data);
                $(targetSelector).trigger("blur"); // in order to trigger validation
            });
        }

        $(sourceSelector).change(function () {
            if (!$(targetSelector).val()) {
                generateSlug();
            }
        });

        $(refreshSelector).click(function (event) {
            event.preventDefault();
            generateSlug();
        });

        

    };
}

var slug = new slugFunc();