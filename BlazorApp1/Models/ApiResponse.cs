﻿namespace BlazorApp1.Models
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public Task<string> Content { get; set; }
    }
}
