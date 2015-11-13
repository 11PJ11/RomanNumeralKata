module WhenConvertingToRoman
 
    open ArabicToRoman
    open NUnit.Framework
    open FsCheck
    open FsCheck.NUnit
    open Swensen.Unquote
    open FsUnit

    [<Test>]
    //used to enable test discovery in NCrunch
    let ``ignore me`` () = ()


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

    

    let ReturnsTheRomanDigit(arabic, roman) = 
        test <@ arabic |> convertToRoman = RomanNumeral roman @>

    [<Test>]
    let Verify() =
        ReturnsTheRomanDigit(1, [I])
        ReturnsTheRomanDigit(2, [I;I])
        ReturnsTheRomanDigit(3, [I;I;I])
        ReturnsTheRomanDigit(5, [V])
