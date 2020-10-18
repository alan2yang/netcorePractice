using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FirstWeb.Models
{
    public enum ClassNameEnum
    {
        [Display(Name = "一年级")]
        FirstGrade,
        [Display(Name = "二年级")]
        SecondGrade,
        [Display(Name = "三年级")]
        GradeThree
    }

    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "请输入名字"), MaxLength(50, ErrorMessage = "名字的长度不能超过50个字符")]
        [Display(Name = "名字")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "班级信息")]
        public ClassNameEnum? ClassName { get; set; }

        [Display(Name = "电子邮件")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "邮箱的格式不正确")]

        [Required(ErrorMessage = "请输入邮箱地址")]
        public string Email { get; set; }
    }
}
