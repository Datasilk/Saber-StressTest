(function () {
    var iframes = S('.iframes');
    for (var x = 0; x < 24; x++) {
        var iframe = document.createElement('iframe');
        iframe.id = 'iframe_' + x;
        iframe.src = '/test-' + (Math.floor(Math.random() * 100));
        iframes.append(iframe);
    }

    var totalTime = S('.total-time');
    var totalLoaded = S('.total-loaded');
    var total500 = S('.total-500');
    var totalAvg = S('.total-avg');
    var datestart = Date.now();
    window.total = {
        loaded: 0,
        time: 0
    };
    S('iframe').on('load', (e) => {
        var dif = Date.now() - datestart;
        totalTime.html(
            ("0" + Math.round(dif / 1000 / 60 / 60)).slice(-2) + ':' +
            ("0" + Math.round(dif / 1000 / 60)).slice(-2) + ':' +
            ("0" + Math.round(dif / 1000)).slice(-2)
        );
        totalLoaded.html('Total loaded: ' + total.loaded);
        if (total.loaded == 500) {
            total500.html('Time to 500: ' + (dif / 1000).toFixed(1) + ' seconds');
            totalAvg.html('Avg load time: ' + (total.time / 500).toFixed(1)) + ' ms';
        }
    });
})();