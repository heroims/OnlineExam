using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 在线考试系统.Model
{
    class PaperDetail
    {
        #region 私有成员
        int _paperID;
        string _type;
        int _titleID;
        int _mark;
        int _writeTime;
        int _TID;
        #endregion        
        #region 公有成员
        public int PaperID
        {
            get { return _paperID; }
            set { _paperID = value; }
        }
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public int TitleID
        {
            get { return _titleID; }
            set { _titleID = value; }
        }
        public int Mark
        {
            get { return _mark; }
            set { _mark = value; }
        }
        public int WriteTime
        {
            get { return _writeTime; }
            set { _writeTime = value; }
        }
        public int TID
        {
            get { return _TID; }
            set { _TID = value; }
        }
        #endregion
        public PaperDetail() { }
        public PaperDetail(int paperID, string type, int titleID, int mark, int writeTime)
        {
            _paperID = paperID;
            _type = type;
            _titleID = titleID;
            _mark = mark;
            _writeTime = writeTime;
        }
    }
}
