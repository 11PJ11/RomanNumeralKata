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
    
    let VerifyExpansion number expansion =
         test <@ expand number = expansion @>
    
    [<Test>]
    let It_should_return_the_expanded_form_for_a_number =
        VerifyExpansion 0 [{power = Power(0); digit = Digit(0)}]
        VerifyExpansion 1 [{power = Power(0); digit = Digit(1)}]
        VerifyExpansion 5 [{power = Power(0); digit = Digit(5)}]
        VerifyExpansion 15 [{power = Power(1); digit = Digit(1)};
                            {power = Power(0); digit = Digit(5)}]
        VerifyExpansion 203 [{power = Power(2); digit = Digit(2)};
                             {power = Power(0); digit = Digit(3)}]
        VerifyExpansion 2499 [
                             {power = Power(3); digit = Digit(2)};
                             {power = Power(2); digit = Digit(4)};
                             {power = Power(1); digit = Digit(9)};
                             {power = Power(0); digit = Digit(9)}]
    
    let ReturnsTheRomanDigit(arabic, roman) = 
        test <@ arabic |> convertToRoman = roman @>

    [<Test>]
    let Verify() =
        ReturnsTheRomanDigit(0, "")
        ReturnsTheRomanDigit(1, "I")
        ReturnsTheRomanDigit(2, "II")
        ReturnsTheRomanDigit(3, "III")
        ReturnsTheRomanDigit(4, "IV")
        ReturnsTheRomanDigit(5, "V")
        ReturnsTheRomanDigit(6, "VI")
        ReturnsTheRomanDigit(10, "X")
        ReturnsTheRomanDigit(15, "XV")
        ReturnsTheRomanDigit(20, "XX")
        ReturnsTheRomanDigit(37, "XXXVII")
