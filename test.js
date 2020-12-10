(function () {
    function redirect() {
        //set up AJAX request
        var req = new XMLHttpRequest();

        //set up callbacks
        req.onload = function () {
            if (req.status >= 200 && req.status < 400) {
                //request success
                document.location.href = req.responseText;
            } else {
                //connected to server, but returned an error
                console.log('An unknown error occurred');
            }
        };

        req.onerror = function () {
            //an error occurred before connecting to server
            console.log('An error occurred when contacting the server');
        };

        //finally, send AJAX request
        req.open('POST', '/api/StressTest/RandomTest');
        req.setRequestHeader('Content-Type', 'text/html');
        req.send();
    }
    redirect();
})();