﻿using Microsoft.AspNetCore.Http;
using ToolSeoViet.Database;

namespace ToolSeoViet.Services.Common {

    public class BaseService {
        protected readonly ToolSeoVietContext db;
        protected readonly IHttpContextAccessor httpContextAccessor;
        protected readonly string currentUserId;
        protected readonly string currentUrl;

        protected BaseService(ToolSeoVietContext db, IHttpContextAccessor httpContextAccessor) {
            this.db = db;
            this.httpContextAccessor = httpContextAccessor;

            var httpContext = httpContextAccessor.HttpContext;
            if (httpContext != null) {
                this.currentUserId = httpContext.User?.FindFirst(o => o.Type == "UserId")?.Value ?? "";
                this.currentUrl = this.GetCurrentUrl(httpContext.Request);
            }
        }

        private string GetCurrentUrl(HttpRequest httpRequest) {
            if (httpRequest == null) return default;
            return $"{httpRequest.Scheme}://{httpRequest.Host.Value}/";
        }
    }
}