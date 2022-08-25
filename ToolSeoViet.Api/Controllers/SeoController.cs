﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ToolSeoViet.Service.Interfaces;
using ToolSeoViet.Service.Models.Seo;
using ToolSeoViet.Services.Interfaces;
using ToolSeoViet.Services.Models;
using ToolSeoViet.Services.Models.Auth;

namespace ToolSeoViet.Api.Controllers {
    [ApiController, Authorize, Route("api/seo/")]
    public class SeoController : ControllerBase {
        private readonly ISeoService seoService;

        public SeoController(ISeoService seoService) {
            this.seoService = seoService;
        }

        [HttpPost, Route("content")]
        public async Task<BaseResponse> SearchContents(SearchContentRequest request) {
            try {
                var response = await this.seoService.GetContennt(request);
                return BaseResponse<SearchContentDto>.Ok(response);
            } catch (Exception ex) {
                return BaseResponse.Fail(ex.Message);
            }
        }

        [HttpPost, Route("search-index")]
        public async Task<BaseResponse> Index(SearchIndexRequest request) {
            try {
                var response = await this.seoService.Index(request);
                return BaseResponse<SearchIndex>.Ok(response);
            } catch (Exception ex) {
                return BaseResponse.Fail(ex.Message);
            }
        }
    }
}

