const { createProxyMiddleware } = require('http-proxy-middleware');
const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:6562';

const context =  [
  "/api/city",
  "/api/restaurant/getallbycity",
  "/api/restaurant/getall",
  "/api/user/login",
  "/api/user/register",
  "/api/restaurateur/become",
  "/api/restaurateur/getallcandidates",
  "/api/restaurateur/approvecandidate",
  "/api/restaurant/createrestaurant",
  "/api/restaurant/detailsrestaurant",
  "/api/product/addProduct",
  "/api/cart/getcartbyuserid",
  "/api/cart/addproducttocart",
  "/api/cart/removeproductfromcart"
];

module.exports = function(app) {
  const appProxy = createProxyMiddleware(context, {
    target: target,
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    }
  });

  app.use(appProxy);
};
