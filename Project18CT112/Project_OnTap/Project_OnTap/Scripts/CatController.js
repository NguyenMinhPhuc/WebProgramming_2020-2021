var category = {
    init: function () {
        category.registerEvent();
    },
    registerEvent: function () {
        $('.btn-Change').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Cat/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",

                success: function (response) {
                    if(response.status === 1)
                    {
                        btn.text('Kích hoạt');
                    } else {
                        btn.text('Khóa');
                    }
                }
            });
        });
    }
}
category.init();