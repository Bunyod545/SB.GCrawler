namespace SB.GCrawler.Services.RobotsTexts
{
    /// <summary>
    /// 
    /// </summary>
    public class RobotsTextsLineHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public RobotsTextLine ParseLine(string line, int lineIndex)
        {
            var textLine = ParseLine(line);
            textLine.LineNumber = lineIndex + 1;

            return textLine;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public RobotsTextLine ParseLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                return new RobotsTextEmptyLine();

            if (IsCommentLine(line))
                return new RobotsTextCommentLine(line);

            if (IsLineStartsWith(line, RobotsTextConsts.UserAgentKey))
                return ParseUserAgentLine(line);

            if (IsLineStartsWith(line, RobotsTextConsts.AllowKey))
                return ParseAllowLine(line);

            if (IsLineStartsWith(line, RobotsTextConsts.DisallowKey))
                return ParseDisallowLine(line);

            if (IsLineStartsWith(line, RobotsTextConsts.SiteMapKey))
                return ParseSiteMapLine(line);

            return new RobotsTextUnknownLine(line);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public bool IsCommentLine(string line)
        {
            return line.TrimStart().StartsWith(RobotsTextConsts.CommentKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <param name="startsText"></param>
        /// <returns></returns>
        public bool IsLineStartsWith(string line, string startsText)
        {
            var lineText = line.RemoveWhiteSpace().ToLower();
            var startsKey = startsText + RobotsTextConsts.Delimmer;

            return lineText.StartsWith(startsKey.ToLower());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private RobotsTextUserAgentLine ParseUserAgentLine(string line)
        {
            var lineValue = ExtractLineValue(line);
            return new RobotsTextUserAgentLine(lineValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private RobotsTextAllowLine ParseAllowLine(string line)
        {
            var lineValue = ExtractLineValue(line);
            return new RobotsTextAllowLine(lineValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private RobotsTextDisallowLine ParseDisallowLine(string line)
        {
            var lineValue = ExtractLineValue(line);
            return new RobotsTextDisallowLine(lineValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private RobotsTextSiteMapLine ParseSiteMapLine(string line)
        {
            var lineValue = ExtractLineValue(line);
            return new RobotsTextSiteMapLine(lineValue);
        }

        /// <summary>
        /// 
        /// /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public RobotsTextLineValue ExtractLineValue(string line)
        {
            var delimmerIndex = line.IndexOf(RobotsTextConsts.Delimmer);
            if (delimmerIndex == -1)
                return null;

            var value = line.Substring(delimmerIndex + 1).Trim();
            var lineValue = new RobotsTextLineValue();
            lineValue.Value = value;

            var commentIndex = lineValue.Value.IndexOf(RobotsTextConsts.CommentKey);
            if (commentIndex != -1)
            {
                lineValue.Value = value.Substring(0, commentIndex).Trim();
                lineValue.Comment = value.Substring(commentIndex + 1).Trim();
            }

            return lineValue;
        }
    }
}