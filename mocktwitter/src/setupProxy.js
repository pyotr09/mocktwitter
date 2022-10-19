const { createProxyMiddleware } = require('http-proxy-middleware');

const context = [
    "/mocktweets", "/users", "/timeline/**", "/userfollow"
];

module.exports = function (app) {
    const appProxy = createProxyMiddleware(context, {
        target: 'https://localhost:7086'
    });

    app.use(appProxy);
};
