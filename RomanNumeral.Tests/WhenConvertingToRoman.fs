module WhenConvertingToRoman

    open NUnit.Framework
    open FsCheck
    open FsCheck.NUnit
    open Swensen.Unquote

    [<Test>]
    //used to enable test discovery in NCrunch
    let ignore_me () = ()


//    Conversion Table
//    1    - I
//    5    - V
//    10   - X
//    50   - L
//    100  - C
//    500  - D
//    1000 - M
//    2499 - MMCDXCIX
//    3949 - MMMCMXLIX

    