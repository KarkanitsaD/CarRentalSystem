﻿using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Business.Exceptions;
using Microsoft.AspNetCore.Http;

namespace API.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException e)
            {
                context.Response.StatusCode = (int) HttpStatusCode.NotFound;
                await context.Response.WriteAsync(JsonSerializer.Serialize(e.Message));
            }
            catch (BadRequestException e)
            {
                context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                await context.Response.WriteAsync(JsonSerializer.Serialize(e.Message));
            }
            catch (NotAuthorizedException e)
            {
                context.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync(JsonSerializer.Serialize(e.Message));
            }
            catch (NotAuthenticatedException e)
            {
                context.Response.StatusCode = (int) HttpStatusCode.Forbidden;
                await context.Response.WriteAsync(JsonSerializer.Serialize(e.Message));
            }
            catch (Exception e)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(JsonSerializer.Serialize(e.ToString()));
            }
        }
    }
}