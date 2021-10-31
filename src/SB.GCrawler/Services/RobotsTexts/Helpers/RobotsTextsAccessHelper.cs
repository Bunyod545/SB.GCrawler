using System.Linq;
using System;
namespace SB.GCrawler.Services.RobotsTexts
{
    /// <summary>
    /// 
    /// </summary>
    public class RobotsTextsAccessHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userAgent"></param>
        /// <param name="uri"></param>
        /// <returns></returns>
        public bool IsAllowed(RobotsTextUserAgent userAgent, Uri requestUri)
        {
            var requestPath = requestUri.PathAndQuery;
            if (requestUri.LocalPath == "/robots.txt")
                return true;

            if (userAgent == null)
                return true;

            foreach (var rule in userAgent.Rules)
            {
                if (rule.RuleType == RobotsTextRuleType.Disallow && rule.Url == string.Empty)
                    return true;

                if (PathMatch(rule.Url, requestPath))
                    return rule.RuleType == RobotsTextRuleType.Allow;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceRecord"></param>
        /// <param name="uriPath"></param>
        /// <param name="comparison"></param>
        /// <returns></returns>
        public bool PathMatch(string sourceRecord, string uriPath)
        {
            var sourcePieces = sourceRecord.Split(new[] { '*' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var lastPiece = sourcePieces.LastOrDefault();
            var mustMatchToEnd = false;
            var mustMatchToStart = true;

            if (lastPiece != null && lastPiece.EndsWith("$"))
            {
                //Remove the last dollar sign from the last piece
                lastPiece = lastPiece.Substring(0, lastPiece.Length - 1);
                sourcePieces[sourcePieces.Length - 1] = lastPiece;
                mustMatchToEnd = true;
            }

            if (sourceRecord.StartsWith("*") || sourceRecord.EndsWith("/"))
                mustMatchToStart = false;

            var offsetPosition = 0;

            for (int i = 0, l = sourcePieces.Length; i < l; i++)
            {
                var piece = sourcePieces[i];
                var indexPosition = uriPath.IndexOf(piece, offsetPosition);

                if (mustMatchToStart && offsetPosition == 0 && indexPosition > 0)
                    return false;

                if (indexPosition >= offsetPosition)
                {
                    offsetPosition = piece.Length;
                }
                else
                {
                    return false;
                }

            }

            if (mustMatchToEnd)
            {
                var endOffset = uriPath.Length - lastPiece.Length;
                if (uriPath.IndexOf(lastPiece, endOffset) == -1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}