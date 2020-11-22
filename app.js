var pusher = new Pusher('XXX_APP_KEY', {
    cluster: 'XXX_APP_CLUSTER'
});
var my_channel = pusher.subscribe('asp_channel');
var app = new Vue({
    el: '#app',
    data: {
        comments: [],
        comment: {
            Name: '',
            Body: '',
            BlogPostID: @Model.BlogPostID
                }
        },
        created: function() {
            this.get_comments();
            this.listen();
        },
        methods: {
            get_comments: function() {
                axios.get('@Url.Action("Comments", "Home", new { id = @Model.BlogPostID }, protocol: Request.Url.Scheme)')
                    .then((response) => {

                        this.comments = response.data;

                    });

            },
            listen: function() {
                my_channel.bind("asp_event", (data) => {
                    if (data.BlogPostID == this.comment.BlogPostID) {
                        this.comments.push(data);
                    }

                })
            },
            submit_comment: function() {
                axios.post('@Url.Action("Comment", "Home", new {}, protocol: Request.Url.Scheme)', this.comment)
                    .then((response) => {
                        this.comment.Name = '';
                        this.comment.Body = '';
                        alert("Comment Submitted");

                    });
            }
        }
    });
