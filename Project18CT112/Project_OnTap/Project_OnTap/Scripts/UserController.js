var user = {
    init:function(){
        user.registerEvent();
    },
    registerEvent: function () {
        $('.btn-active').off('click').on('click', function (e) {
           //e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/User/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",
      
                success: function (response) {
                    console.log(response);
                    if (response.status === '1') {
                        btn.text('Kích hoạt');
                    } else {
                        btn.text = 'Khóa';
                    }
                }
            });
        });
    }
   
}
user.init();