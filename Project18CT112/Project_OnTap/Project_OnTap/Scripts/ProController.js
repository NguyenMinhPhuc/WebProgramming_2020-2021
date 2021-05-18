var product = {
    init:function(){
        product.registerEvent();
    },
    registerEvent:function(){
        $('.btn-active').off('click').on('click', function (e) {
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: '/Product/ChangeStatus',
                data: { id: id },
                dataType: "json",
                type: "POST",

                success: function (response) {
                    console.log(response);
                    if (response.status === 1)
                        btn.text('Kích hoạt');
                    else
                        btn.text('Khóa');
                }
            });
        });
    }
}
product.init();