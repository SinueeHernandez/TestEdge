var edge = require('edge');

var addAndMultiplyBy2 = edge.func(function () {/*
    async (dynamic input) => {
        var add = (Func<object, Task<object>>)input.add;
        var twoNumbers = new { a = (int)input.a, b = (int)input.b };
        var addResult = (int)await add(twoNumbers);
        return addResult * 2;
    }   
*/});

var payload = {
    a: 2,
    b: 3,
    add: function (data, callback) {
        callback(null, data.a + data.b);
    }
};

addAndMultiplyBy2(payload, function (error, result) {
    if (error) throw error;
    console.log(result);
});