using AdapterExceptions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SessionInterface;
using System;
using System.Collections.Generic;
using WebApi.Filters;

namespace WebApiTests
{
    [TestClass]
    public class FilterTest
    {

        [TestMethod]
        public void AuthorizationAttributeFilterValidToken()
        {
            IHeaderDictionary headers = new HeaderDictionary();
            headers.Add("Authorization", Guid.NewGuid().ToString());
            Mock<HttpRequest> mockHttpRequest = new Mock<HttpRequest>();
            mockHttpRequest.Setup(r => r.Headers).Returns(headers);
            Mock<ISessionLogic> mockSessionLogic = new Mock<ISessionLogic>();
            mockSessionLogic.Setup(s => s.IsValidToken(It.IsAny<string>())).Returns(true);
            Mock<HttpContext> mockHttpContext = new Mock<HttpContext>();
            mockHttpContext.Setup(h => h.Request).Returns(mockHttpRequest.Object);
            mockHttpContext.Setup(h => h.RequestServices.GetService(It.IsAny<Type>())).Returns(mockSessionLogic.Object);
            ActionContext actionContext = new ActionContext(
                mockHttpContext.Object,
                new Mock<Microsoft.AspNetCore.Routing.RouteData>().Object,
                new Mock<ActionDescriptor>().Object);
            AuthorizationFilterContext actionExecutingContext = new AuthorizationFilterContext(
                actionContext,
                new Mock<IList<IFilterMetadata>>().Object);
            AuthorizationFilter filter = new AuthorizationFilter(mockSessionLogic.Object);

            filter.OnAuthorization(actionExecutingContext);

            Assert.IsNull(actionExecutingContext.Result);
        }

        [TestMethod]
        public void AuthorizationAttributeFilterInvalidToken()
        {
            IHeaderDictionary headers = new HeaderDictionary();
            headers.Add("Authorization", Guid.NewGuid().ToString());
            Mock<HttpRequest> mockHttpRequest = new Mock<HttpRequest>();
            mockHttpRequest.Setup(r => r.Headers).Returns(headers);
            Mock<ISessionLogic> mockSessionLogic = new Mock<ISessionLogic>();
            mockSessionLogic.Setup(s => s.IsValidToken(It.IsAny<string>())).Returns(false);
            Mock<HttpContext> mockHttpContext = new Mock<HttpContext>();
            mockHttpContext.Setup(h => h.Request).Returns(mockHttpRequest.Object);
            mockHttpContext.Setup(h => h.RequestServices.GetService(It.IsAny<Type>())).Returns(mockSessionLogic.Object);
            ActionContext actionContext = new ActionContext(
                mockHttpContext.Object,
                new Mock<Microsoft.AspNetCore.Routing.RouteData>().Object,
                new Mock<ActionDescriptor>().Object);
            AuthorizationFilterContext actionExecutingContext = new AuthorizationFilterContext(
                actionContext,
                new Mock<IList<IFilterMetadata>>().Object);
            AuthorizationFilter filter = new AuthorizationFilter(mockSessionLogic.Object);

            filter.OnAuthorization(actionExecutingContext);
            var result = actionExecutingContext.Result as ContentResult;

            Assert.AreEqual(403, result.StatusCode);
        }

        [TestMethod]
        public void AuthorizationAttributeFilterNotToken()
        {
            IHeaderDictionary headers = new HeaderDictionary();
            headers.Add("Authorization", "");
            Mock<HttpRequest> mockHttpRequest = new Mock<HttpRequest>();
            mockHttpRequest.Setup(r => r.Headers).Returns(headers);
            Mock<ISessionLogic> mockSessionLogic = new Mock<ISessionLogic>();
            mockSessionLogic.Setup(s => s.IsValidToken(It.IsAny<string>())).Returns(false);
            Mock<HttpContext> mockHttpContext = new Mock<HttpContext>();
            mockHttpContext.Setup(h => h.Request).Returns(mockHttpRequest.Object);
            mockHttpContext.Setup(h => h.RequestServices.GetService(It.IsAny<Type>())).Returns(mockSessionLogic.Object);
            ActionContext actionContext = new ActionContext(
                mockHttpContext.Object,
                new Mock<Microsoft.AspNetCore.Routing.RouteData>().Object,
                new Mock<ActionDescriptor>().Object);
            AuthorizationFilterContext actionExecutingContext = new AuthorizationFilterContext(
                actionContext,
                new Mock<IList<IFilterMetadata>>().Object);
            AuthorizationFilter filter = new AuthorizationFilter(mockSessionLogic.Object);

            filter.OnAuthorization(actionExecutingContext);
            var result = actionExecutingContext.Result as ContentResult;

            Assert.AreEqual(401, result.StatusCode);
        }

        [TestMethod]
        public void TestExceptionFilterAmountOfProblematicsException()
        {
            var actionContext = new ActionContext()
            {
                HttpContext = new DefaultHttpContext(),
                RouteData = new Microsoft.AspNetCore.Routing.RouteData(),
                ActionDescriptor = new ActionDescriptor()
            };
            var mockException = new Mock<AmountOfProblematicsException>("AmountOfProblematicsException");
            var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>())
            {
                Exception = mockException.Object
            };
            var filter = new ExceptionFilter();

            filter.OnException(exceptionContext);
            var s = exceptionContext.Result as ContentResult;

            Assert.AreEqual(400, s.StatusCode);
        }

        [TestMethod]
        public void TestExceptionFilterInvalidAttributeExceptionException()
        {
            var actionContext = new ActionContext()
            {
                HttpContext = new DefaultHttpContext(),
                RouteData = new Microsoft.AspNetCore.Routing.RouteData(),
                ActionDescriptor = new ActionDescriptor()
            };
            var mockException = new Mock<InvalidAttributeException>("Invalid Attribute Exception");
            var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>())
            {
                Exception = mockException.Object
            };
            var filter = new ExceptionFilter();

            filter.OnException(exceptionContext);
            var s = exceptionContext.Result as ContentResult;

            Assert.AreEqual(400, s.StatusCode);
        }

        [TestMethod]
        public void TestExceptionFilterNotFoundException()
        {
            var actionContext = new ActionContext()
            {
                HttpContext = new DefaultHttpContext(),
                RouteData = new Microsoft.AspNetCore.Routing.RouteData(),
                ActionDescriptor = new ActionDescriptor()
            };
            var mockException = new Mock<NotFoundException>("Not Found Exception");
            var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>())
            {
                Exception = mockException.Object
            };
            var filter = new ExceptionFilter();

            filter.OnException(exceptionContext);
            var s = exceptionContext.Result as ContentResult;

            Assert.AreEqual(404, s.StatusCode);
        }

        [TestMethod]
        public void TestExceptionFilterEntityAlreadyExistException()
        {
            var actionContext = new ActionContext()
            {
                HttpContext = new DefaultHttpContext(),
                RouteData = new Microsoft.AspNetCore.Routing.RouteData(),
                ActionDescriptor = new ActionDescriptor()
            };
            var mockException = new Mock<EntityAlreadyExistException>("Entity Already Exist Exception");
            var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>())
            {
                Exception = mockException.Object
            };
            var filter = new ExceptionFilter();

            filter.OnException(exceptionContext);
            var s = exceptionContext.Result as ContentResult;

            Assert.AreEqual(400, s.StatusCode);
        }

        [TestMethod]
        public void TestExceptionFilterException()
        {
            var actionContext = new ActionContext()
            {
                HttpContext = new DefaultHttpContext(),
                RouteData = new Microsoft.AspNetCore.Routing.RouteData(),
                ActionDescriptor = new ActionDescriptor()
            };
            var mockException = new Mock<Exception>("Exception");
            var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>())
            {
                Exception = mockException.Object
            };
            var filter = new ExceptionFilter();

            filter.OnException(exceptionContext);
            var s = exceptionContext.Result as ContentResult;

            Assert.AreEqual(500, s.StatusCode);
        }

        [TestMethod]
        public void TestInvalidRouteForFileException()
        {
            var actionContext = new ActionContext()
            {
                HttpContext = new DefaultHttpContext(),
                RouteData = new Microsoft.AspNetCore.Routing.RouteData(),
                ActionDescriptor = new ActionDescriptor()
            };
            var mockException = new Mock<InvalidRouteForFileException>("Invalid Route For File Exception");
            var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>())
            {
                Exception = mockException.Object
            };
            var filter = new ExceptionFilter();

            filter.OnException(exceptionContext);
            var s = exceptionContext.Result as ContentResult;

            Assert.AreEqual(400, s.StatusCode);
        }
    }
}