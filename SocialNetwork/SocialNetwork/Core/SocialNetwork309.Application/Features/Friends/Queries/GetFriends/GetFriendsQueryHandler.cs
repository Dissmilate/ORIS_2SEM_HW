using MediatR;
using Microsoft.AspNetCore.Identity;
using SocialNetwork309.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork309.Application.Features.Friends.Queries.GetFriends
{
    /*public class GetFriendsQueryHandler : IRequestHandler<GetFriendsQuery, List<IdentityUser>>
    {
        private readonly IFriendService _friendService;

        public GetFriendsQueryHandler(IFriendService friendService)
        {
            _friendService = friendService;
        }

        public async Task<List<IdentityUser>> Handle(GetFriendsQuery query, CancellationToken cancellationToken)
        {
            return await _friendService.GetFriendsAsync(query.UserId);
        }
    }*/
}
