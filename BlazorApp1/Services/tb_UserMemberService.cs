using BlazorApp1.Models;
using BlazorApp1.ResourceParameters;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Services
{
    public class tb_UserMemberService : Itb_UserMemberService
    {
        private readonly HttpClient httpClient;

        public tb_UserMemberService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<tb_UserMember>> Search([FromQuery] UserMemberParamaters paramaters)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<tb_UserMember>>($"tb_UserMember/Search?Account1={paramaters.Account1}&UserName1={paramaters.UserName1}&Tel1={paramaters.Tel1}");
        }

        public async Task<ApiResponse> Add(tb_UserMember list)
        {
            var response = await httpClient.PostAsJsonAsync<tb_UserMember>($"tb_UserMember/Add", list);
            var apiResponse = new ApiResponse
            {
                StatusCode = (int)response.StatusCode,
                Message = response.ReasonPhrase,
                Content = response.Content.ReadAsStringAsync()
            };

            return apiResponse;
        }

        public async Task<ApiResponse> Update(tb_UserMember list)
        {
            var response = await httpClient.PutAsJsonAsync<tb_UserMember>($"tb_UserMember/Update/{list.Id}", list);
            var apiResponse = new ApiResponse
            {
                StatusCode = (int)response.StatusCode,
                Message = response.ReasonPhrase,
                Content = response.Content.ReadAsStringAsync()
            };

            return apiResponse;
        }

        public async Task Delete(int Id)
        {
            await httpClient.DeleteAsync($"tb_UserMember/Delete/{Id}");
        }
    }
}
