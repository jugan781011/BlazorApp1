using BlazorApp1.Models;
using BlazorApp1.ResourceParameters;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Services
{
    public interface Itb_UserMemberService
    {
        Task<IEnumerable<tb_UserMember>> Search([FromQuery] UserMemberParamaters paramaters);
        Task<ApiResponse> Add(tb_UserMember list);
        Task<ApiResponse> Update(tb_UserMember list);
        Task Delete(int Id);
    }
}
