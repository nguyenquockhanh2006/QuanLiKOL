var make = function () {
    const getRandomInt = (min, max) => {
        return Math.floor(Math.random() * (max - min)) + min;
    };
    return getRandomInt(10000, 99999)
}
