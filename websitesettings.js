(function () {
    S('.prepare-stress-test button').on('click', () => {
        S.ajax.post('StressTest/Prepare', {}, () => {
            S('.prepare-stress-test').addClass('hide');
            S('.run-stress-test').removeClass('hide');
            S('.delete-stress-test').removeClass('hide');
        })
    });

    S('.delete-stress-test button').on('click', () => {
        S.ajax.post('StressTest/Delete', {}, () => {
            S('.prepare-stress-test').removeClass('hide');
            S('.run-stress-test').addClass('hide');
            S('.delete-stress-test').addClass('hide');
        })
    });
})();