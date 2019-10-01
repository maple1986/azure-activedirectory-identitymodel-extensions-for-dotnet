﻿//------------------------------------------------------------------------------
//
// Copyright (c) Microsoft Corporation.
// All rights reserved.
//
// This code is licensed under the MIT License.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files(the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and / or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions :
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Protocols.Pop.SignedHttpRequest;
using Microsoft.IdentityModel.Tokens;

namespace Microsoft.IdentityModel.Protocols.PoP.Tests.SignedHttpRequest
{
    /// <summary>
    /// Mock SignedHttpRequestHandler.
    /// </summary>
    public class SignedHttpRequestHandlerPublic : SignedHttpRequestHandler
    {
        public async Task<string> CreateSignedHttpRequestPublicAsync(SignedHttpRequestCreationData signedHttpRequestCreationData, CancellationToken cancellationToken)
        {
            return await CreateSignedHttpRequestAsync(signedHttpRequestCreationData, cancellationToken).ConfigureAwait(false);
        }

        public string CreateHttpRequestHeaderPublic(SignedHttpRequestCreationData signedHttpRequestCreationData)
        {
            return base.CreateHttpRequestHeader(signedHttpRequestCreationData);
        }

        public string CreateHttpRequestPayloadPublic(SignedHttpRequestCreationData signedHttpRequestCreationData)
        {
            return base.CreateHttpRequestPayload(signedHttpRequestCreationData);
        }

        public async Task<string> SignHttpRequestPublicAsync(string header, string payload, SignedHttpRequestCreationData signedHttpRequestCreationData, CancellationToken cancellationToken)
        {
            return await base.SignHttpRequestAsync(header, payload, signedHttpRequestCreationData, cancellationToken).ConfigureAwait(false);
        }

        public string ConvertToJsonPublic(Dictionary<string, object> payload)
        {
            return base.ConvertToJson(payload);
        }

        public void AddAtClaimPublic(Dictionary<string, object> payload, SignedHttpRequestCreationData signedHttpRequestCreationData)
        {
            base.AddAtClaim(payload, signedHttpRequestCreationData);
        }
   
        public void AddTsClaimPublic(Dictionary<string, object> payload, DateTime now, SignedHttpRequestCreationData signedHttpRequestCreationData)
        {
            if (payload == null)
                throw LogHelper.LogArgumentNullException(nameof(payload));

            var signedHttpRequestCreationTime = now.Add(signedHttpRequestCreationData.SignedHttpRequestCreationPolicy.TimeAdjustment);
            payload.Add(Pop.PopConstants.SignedHttpRequest.ClaimTypes.Ts, (long)(signedHttpRequestCreationTime - EpochTime.UnixEpoch).TotalSeconds);
        }

        public void AddMClaimPublic(Dictionary<string, object> payload, SignedHttpRequestCreationData signedHttpRequestCreationData)
        {
            base.AddMClaim(payload, signedHttpRequestCreationData);
        }

        public void AddUClaimPublic(Dictionary<string, object> payload, SignedHttpRequestCreationData signedHttpRequestCreationData)
        {
            base.AddUClaim(payload, signedHttpRequestCreationData);
        }

        public void AddPClaimPublic(Dictionary<string, object> payload, SignedHttpRequestCreationData signedHttpRequestCreationData)
        {
            base.AddPClaim(payload, signedHttpRequestCreationData);
        }

        public void AddQClaimPublic(Dictionary<string, object> payload, SignedHttpRequestCreationData signedHttpRequestCreationData)
        {
            base.AddQClaim(payload, signedHttpRequestCreationData);
        }
 
        public void AddHClaimPublic(Dictionary<string, object> payload, SignedHttpRequestCreationData signedHttpRequestCreationData)
        {
            base.AddHClaim(payload, signedHttpRequestCreationData);
        }

        public void AddBClaimPublic(Dictionary<string, object> payload, SignedHttpRequestCreationData signedHttpRequestCreationData)
        {
            base.AddBClaim(payload, signedHttpRequestCreationData);
        }

        public void AddNonceClaimPublic(Dictionary<string, object> payload, SignedHttpRequestCreationData signedHttpRequestCreationData)
        {
            base.AddNonceClaim(payload, signedHttpRequestCreationData);
        }

        public async Task<SignedHttpRequestValidationResult> ValidateSignedHttpRequestPublicAsync(SignedHttpRequestValidationData signedHttpRequestValidationData, CancellationToken cancellationToken)
        {
            return await base.ValidateSignedHttpRequestAsync(signedHttpRequestValidationData, cancellationToken).ConfigureAwait(false);
        }

        public async Task<TokenValidationResult> ValidateAccessTokenPublicAsync(string accessToken, SignedHttpRequestValidationData signedHttpRequestValidationData, CancellationToken cancellationToken)
        {
            return await base.ValidateAccessTokenAsync(accessToken, signedHttpRequestValidationData, cancellationToken).ConfigureAwait(false);
        }

        public async Task<SecurityToken> ValidateSignedHttpRequestPublicAsync(SecurityToken jwtSignedHttpRequest, SecurityToken validatedAccessToken, SignedHttpRequestValidationData signedHttpRequestValidationData, CancellationToken cancellationToken)
        {
            return await base.ValidateSignedHttpRequestAsync(jwtSignedHttpRequest, validatedAccessToken, signedHttpRequestValidationData, cancellationToken).ConfigureAwait(false);
        }

        public async Task ValidateSignedHttpRequestSignaturePublicAsync(SecurityToken jwtSignedHttpRequest, SecurityToken validatedAccessToken, SignedHttpRequestValidationData signedHttpRequestValidationData, CancellationToken cancellationToken)
        {
            await base.ValidateSignedHttpRequestSignatureAsync(jwtSignedHttpRequest, validatedAccessToken, signedHttpRequestValidationData, cancellationToken).ConfigureAwait(false);
        }

        public void ValidateTsClaimPublic(SecurityToken jwtSignedHttpRequest, SignedHttpRequestValidationData signedHttpRequestValidationData)
        {
            base.ValidateTsClaim(jwtSignedHttpRequest, signedHttpRequestValidationData);
        }
    
        public void ValidateMClaimPublic(SecurityToken jwtSignedHttpRequest, SignedHttpRequestValidationData signedHttpRequestValidationData)
        {
            base.ValidateMClaim(jwtSignedHttpRequest, signedHttpRequestValidationData);
        }

        public void ValidateUClaimPublic(SecurityToken jwtSignedHttpRequest, SignedHttpRequestValidationData signedHttpRequestValidationData)
        {
            base.ValidateUClaim(jwtSignedHttpRequest, signedHttpRequestValidationData);
        }

        public void ValidatePClaimPublic(SecurityToken jwtSignedHttpRequest, SignedHttpRequestValidationData signedHttpRequestValidationData)
        {
            base.ValidatePClaim(jwtSignedHttpRequest, signedHttpRequestValidationData);
        }
  
        public void ValidateQClaimPublic(SecurityToken jwtSignedHttpRequest, SignedHttpRequestValidationData signedHttpRequestValidationData)
        {
            base.ValidateQClaim(jwtSignedHttpRequest, signedHttpRequestValidationData);
        }
       
        public void ValidateHClaimPublic(SecurityToken jwtSignedHttpRequest, SignedHttpRequestValidationData signedHttpRequestValidationData)
        {
            base.ValidateHClaim(jwtSignedHttpRequest, signedHttpRequestValidationData);
        }

        public void ValidateBClaimPublic(SecurityToken jwtSignedHttpRequest, SignedHttpRequestValidationData signedHttpRequestValidationData)
        {
            base.ValidateBClaim(jwtSignedHttpRequest, signedHttpRequestValidationData);
        }

        public async Task<SecurityKey> ResolvePopKeyPublicAsync(SecurityToken validatedAccessToken, SignedHttpRequestValidationData signedHttpRequestValidationData, CancellationToken cancellationToken)
        {
            return await base.ResolvePopKeyAsync(validatedAccessToken, signedHttpRequestValidationData, cancellationToken).ConfigureAwait(false);
        }

        public string GetCnfClaimValuePublic(SecurityToken validatedAccessToken, SignedHttpRequestValidationData signedHttpRequestValidationData)
        {
            return base.GetCnfClaimValue(validatedAccessToken, signedHttpRequestValidationData);
        }

        public SecurityKey ResolvePopKeyFromJwkPublic(string jwk, SignedHttpRequestValidationData signedHttpRequestValidationData)
        {
            return base.ResolvePopKeyFromJwk(jwk, signedHttpRequestValidationData);
        }

        public async Task<SecurityKey> ResolvePopKeyFromJwePublicAsync(string jwe, SignedHttpRequestValidationData signedHttpRequestValidationData, CancellationToken cancellationToken)
        {
            return await base.ResolvePopKeyFromJweAsync(jwe, signedHttpRequestValidationData, cancellationToken).ConfigureAwait(false);
        }
      
        public async Task<SecurityKey> ResolvePopKeyFromJkuPublicAsync(string jkuSetUrl, SignedHttpRequestValidationData signedHttpRequestValidationData, CancellationToken cancellationToken)
        {
            return await base.ResolvePopKeyFromJkuAsync(jkuSetUrl, signedHttpRequestValidationData, cancellationToken).ConfigureAwait(false);
        }
       
        public async Task<SecurityKey> ResolvePopKeyFromJkuPublicAsync(string jkuSetUrl, string kid, SignedHttpRequestValidationData signedHttpRequestValidationData, CancellationToken cancellationToken)
        {
            return await base.ResolvePopKeyFromJkuAsync(jkuSetUrl, kid, signedHttpRequestValidationData, cancellationToken).ConfigureAwait(false);
        }

        public async Task<IList<SecurityKey>> GetPopKeysFromJkuPublicAsync(string jkuSetUrl, SignedHttpRequestValidationData signedHttpRequestValidationData, CancellationToken cancellationToken)
        {
            return await base.GetPopKeysFromJkuAsync(jkuSetUrl, signedHttpRequestValidationData, cancellationToken).ConfigureAwait(false);
        }

        public async Task<SecurityKey> ResolvePopKeyFromKeyIdentifierPublicAsync(string kid, SecurityToken validatedAccessToken, SignedHttpRequestValidationData signedHttpRequestValidationData, CancellationToken cancellationToken)
        {
            return await base.ResolvePopKeyFromKeyIdentifierAsync(kid, validatedAccessToken, signedHttpRequestValidationData, cancellationToken).ConfigureAwait(false);
        }
    }
}