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

    }
}
