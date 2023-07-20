namespace QuanLyTruongHoc.Models.Utils
{
        public static class CommonConst
        {
            public static readonly string Success = "Success";
            public static readonly string SUCCESS = "SUCCESS";
            public static readonly string Error = "Error";
            public static readonly string Redirect = "Redirect";
            public static readonly string Warning = "Warning";
            public static readonly string PostMessageSuccess = "PostMessageSuccess";
            public static readonly string PostMessageError = "PostMessageError";
            public static readonly string DfDateFormat = "dd/MM/yyyy";
            public static readonly string AdminOrgan = "Admin cơ quan";
            public static readonly string BorrowCart = "BorrowCart";
            public static readonly string DestructionProfile = "DestructionProfile";
            public static readonly int MaxBorrowDoc = 500; //Số tài liệu tối đa đc phép khai thác
            public static readonly int DaysToNotifyInWaitDestruction = 10;

            /// <summary>
            /// ArrCodeTypeDoc dùng để search
            /// </summary>
            public static readonly string[] ArrCodeTypeDoc = { "DocCode", "TypeName", "Subject" };
            /// <summary>
            /// ArrCodeTypeDoc dùng để search
            /// </summary>
            public static readonly string[] ArrCodeTypePhoto = { "Identifier", "ArchivesNumber", "ImageTitle", "Photographer" };
            /// <summary>
            /// ArrCodeTypeDoc dùng để search 
            /// </summary>
            public static readonly string[] ArrCodeTypeVideo = { "Identifier", "ArchivesNumber", "MovieTitle", "Recorder" };
            /// <summary>
            /// ArrCodeTypeDocSpecialize
            /// </summary>
            public static readonly string[] ArrCodeTypeDocSpecialize = { "CodeNumber", "OrganName", "Subject" };

            /// <summary>
            /// ArrCodeTypeDoc dùng để search (mã định danh văn bản, trích yếu, tên loại)
            /// </summary>
            public static readonly string[] ArrCodeTypeDocSearchCurent = { "DocCode", "Subject" };
            /// <summary>
            /// ArrCodeTypeDoc dùng để search (số lưu trữ, tác giả)
            /// </summary>
            public static readonly string[] ArrCodeTypePhotoSearchCurent = { "ArchivesNumber", "Photographer" };
            /// <summary>
            /// ArrCodeTypeDoc dùng để search (số lưu trữ, tác giả)
            /// </summary>
            public static readonly string[] ArrCodeTypeVideoSearchCurent = { "ArchivesNumber", "Recorder" };
            /// <summary>
            /// ArrCodeNumberPc07 (số văn bản)
            /// </summary>
            public static readonly string[] ArrCodeTypeDocSpecializeSearchCurent = { $"CodeNumber" };
            /// <summary>
            /// ArrCodeTypeDocSpecialize
            /// </summary>
            public static readonly string[] ArrCodeTypeProfile = { "FileCode", "Title", "FileNotation" };
            /// <summary>
            /// IdentityNumber code `applieants_id` (CMTND/CCCD của độc giả) 
            /// </summary>
            public const string IdentityNumber = "applieants_id";
            /// <summary>
            /// Mã phân loại hồ sơ mặc định
            /// </summary>
            public const string CodeProfileCategory = "IDProfileCategory";
            /// <summary>
            /// ProceduresStatus code `procedures_status` (Trạng thái GQTTHC/TTHC)
            /// </summary>
            public const string ProceduresStatus = "procedures_status";
            /// <summary>
            /// ProceduresName code procedures_name (Tên thủ tục hành chính )
            /// </summary>
            public const string ProceduresName = "procedures_name";
            /// <summary>
            /// ProceduresCode code `procedures_code` (Thủ tục hành chính) 
            /// </summary>
            public const string ProceduresCode = "procedures_code";
            /// <summary>
            /// Số biên nhận | Mã biên nhận
            /// </summary>
            public const string ReceiptCode = "receipt_code";
            /// <summary>
            /// ProfileOwnerName code ProfileOwner_Name (Tên chủ hồ sơ)
            /// </summary>
            public const string ProfileOwnerName = "ProfileOwner_Name";
            /// <summary>
            /// Linhvuc code => Fields (Lĩnh vực) (Hồ sơ)
            /// </summary>
            public const string Linhvuc = "Fields";
            /// <summary>
            /// FieldsDoc code => Linhvuc (Lĩnh vực) (Tài liệu)
            /// </summary>
            public const string FieldsDoc = "Linhvuc";
            /// <summary>
            /// ProfileApplicantName code => ProfileApplicant_Name (Tên người nộp đơn)
            /// </summary>
            public const string ProfileApplicantName = "ProfileApplicant_Name";
        }
}
