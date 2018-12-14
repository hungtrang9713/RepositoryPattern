$(document).ready(function () {
    BookScreen.loadData();
});

var BookScreen = {
    loadData: function () {
        $.ajax({
            url: "/books",
            success: function (data) {
                $.each(data, function (index, item) {
                    var bookHtml = '<div class="book">\
                                    <div class="name">'+ item.BookName +'</div>\
                                    <div class="description">'+ item.Description +'</div>\
                                </div>'
                    $("#book-screen").append(bookHtml);
                });
            }
        })
    }
}
