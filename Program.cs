namespace Advent_Of_Code_06
{
    internal class Program
    {
        static readonly int SignalLength = 14;
        static void Main(string[] args)
        {
            string data = GetInputData();
            Dictionary<char, int> recentChars = new();
            Queue<KeyValuePair<char, int>> charQueue = new();

            for (int i = 0; i < data.Length && i < SignalLength; i++)
            {
                charQueue.Enqueue(new(data[i], i));
                recentChars[data[i]] = i;
                if (HaveSignal(recentChars))
                {
                    Console.WriteLine($"Signal found in the first {SignalLength} characters!");
                }
            }

            for (int i = SignalLength; i < data.Length; i++)
            {
                (char oldestChar, int position) = charQueue.Dequeue();
                if (recentChars[oldestChar] == position)
                {
                    recentChars.Remove(oldestChar);
                }

                charQueue.Enqueue(new(data[i], i));
                recentChars[data[i]] = i;
                
                if (HaveSignal(recentChars))
                {
                    // note that the answer is 1 higher, because of 0-based indexing
                    Console.WriteLine($"Signal found after processing: {i + 1} characters");
                    break;
                }
            }
        }

        static string GetInputData()
        {
            return "llqnqffqsqttfffbcfcbcbdcczccfssvwswrwddzlddpdhdwwlvlffjllnjjwjqwjjttwbwcwfccdmmnddgvvpwvvgsshnshsgglljfjzjpjfpfjpplddjcchdhvhlhvllvflfbllsdllgppwjjprjpjrrdwrdrggjvjppgbgttdppwhhcshsvvgpvggsllstsggdjdmjjrvjjszjsjbbsffjwjnwwzjjjvqvfftbffbpffndfdzfdfvdfdggmpmbbwgbgnnbtnnnhggdmdffrqrlrhrzzrmzzmbzzcdcwwzffsrrnfnvfnnvppwjjndjnndtdppgcppsmppljlpjjmlldlsltlglwgwcwnwvwddzrrllwjjnvjvwvppjssncnfcnfcfcczfccpjphjphjjjsgszzhthghjhrjrbrtrjrhrsrfftfzftfmmwmpmgghbggjrrsdswddtjjvnnrwrzrpzzlglwggrnrgrfftnffwwgllrqqzbqbbtltbbgdgpgphggspggplggmcmscsffzcfzzbggdrgrqgrrnlrnrbnnzsnnzcctvvnvwvnwnhhwpwtptllpflfcfttwtjjhwjhhbwhbbtppwhwvhvghvhphpwwcgwwhbbfvbffzpzlllrzlrrbnnrngrnrpnnsszbbqffpsffhfshfhzzqhhcgcgfggzmmdllthhrhnrrwggdqdsstccqllflmflfddjwjzjffvjjfgjgdgbdgdngnpgpnpffsnsjnnbbjdbjbtbmmbrrlbbqmqpqrprjjrbbvnbbzvvcwwlfwfggmhhdhsdhsdhshhqfhfrhhqlqttffpmmjzjqjggqzzdfzflfsllshhvjvfvbfvbbjljhhzrzqqszqzsqqswswbsbzszgzdgzzhjzhhvffhthvtthltthghzhvvjttczttlssvvgjjmsjstjjrfjjhbjbnjbjddqrddnbdnbnwbnbqbmqqgtgqtttcmmqbqrrgrrsrszssvpsvvjqjttjpjwwmwfwttczttgccwhcwwrzwzbwwqbqmqnmqqnfnmmmzdmzmpmssdpsslbbmgmbmlmnlldlccvzzlrzzqbqfqlflwlvlhhtrtcttgnnqhnqqtjjphjhwjhwhpwwvdvfddmndncnppcffhllfvfdfllhgslvtsqhtlfdflcjfmqbnctnfnwqrlqbzrcbvldrffcptsgslqcszqcfdvtpggvdqblwcgmdjqrpjdhtrmvrfrzznspqlfhnjsppbpjdggcwjwprpnlnntgfgmflctqphdmzfvpzzmbzmvrqdgchzmdvjdzmfsslpqvhpgznmpspjpdmlfwwjbbwqbfthghclldpmnsbcwlzswrsnfzbdzpcnrrpspdpfqhvmtfjlppqtphvzzqrwhzccnrgrtgfbfgtwvlwsmcvzmqmhsvztmmvpjzfwzgfwntbrsfthdgrcmgtdsvzcllmcshrlqldrvrnmdgbwttmhczvscrdvfgdvrhfvlghhsfbmrptbwmpnvtsrjlpjlbmmjzwwzbdtjlqqdczqgpzfjslccrcrblhplndblghchczbjjfzlsvvrqhvgdsncgpjhjlprhfhswwbmrnszqzhhlrbqpphvgtfsgmdpjwgcmqnvfdhrqmbspjpdrtdbqnbmbpgqwgmltqwrjprvsfjsmpldcqqbvmfhgzltzfvhlnfdqrphzzjrbdvnnjspvnlnnsdzvgqsqztndjpmnbqtwnpzmmfhsswwnnwwlbnpgbrhzchbnsrwwpprhntngsjzvssttqwfvjrdddtfpgtqqzcwljzmdjtgzdqjjvbqgdttdgvqvlfdsgcjhsmdmwrwdcqdflpfjbfzsvjrzrhhcnvcjblwcdvtbgfhfgcwrcjsrzcdrfwtvdqrghdtrjgdmhrfcsnwwwdpvjtpzdqfgrlmrqscjbfgdbgvflhvdjmnmslvsbcbgwplgqljmlzpgrfjwmvqfwmwrhnmdjhdwgjrngvccrbzmhcqthvvtdtmfqvfczhqbfgzgrmdtprznfzjtrcwqgztchtdmzmnwbfbnbttbvzsflcpsjshgphfdlvhdrcpsqnhjjggbnsqrfpwsdznzcwjbcswwndzbpdnfcbdrfgrmqzvtjttltbntznmqfsmqlgqvlqnrvgrnggslqhbplmgpzwlfzbvwdvrchsnhrnvgmzjdprvvspltcdzmdnlgtmrwnwpdndpdqjltcnmsggrvbprslqhfgmzqtppdpsjcmmbvfgmbpdnwdcgnssfgjhzhrjljdwhrzznscndgbscdmbbtbrnzbqzvcjgjgljbjlrrvdhjdllsnjzhwlmjslghrqplwjwssbzzpdzdfhhsqctlcddnfnnvbcwpdvzdcsgcqpctsjtdtnzpggpzsrrhfjtthqcqhtvwzltbdvdnbgwlppblwzjsqqbcpcrthhrhdnzhdnflqlvbzmcjfcrbmgdgqptfqfbmlfbblqdfmnwgvbdhmcmtmvtggqstjpwhvzjhbgpblmdrnggvrvphbglqgfcphmrgfmrwcdchtwfllqwsnbqttwdcvrwgzjfztmcffppqtmnwpgcrgwtjbdtjlmnpmvlzndljglzblwdrggqvbbfvqcbcbpqttrmqlcqnqvrfqsnlpmwlcgfwfcqpgmszfccbqtcqfwlwqrjjhrdbjqvdmfzjgncjqgqbthpgjgbfdvltbhpnbjqqwrsczrthfhmlzjjjgsjtsvgmwfsjngzfqdqzfhvwjrswvnqvsvvsjdbwlwdcsszdngmmhnnqsgvsrvpnndghrwgzztqczvhcrzdpqtrmrnfsfrlpdnbbtshfhplzqvdvzdvwhwsbpnbzlvcbgptdszjlcgfdzchjcsvhzdljvgpwstzwnssvhztcptnhslggnrschvfnmhcnjvldthtfpqzdvltfgnmtgvlrljhwqdzqfmfblstvfnpfcdsqslrqbztrbfzmsfjtjwhlzfnhrvpfqfqvtdllrvchmqphgljwcspgpwsdwqfdhsqhsflpbcbjjmjrfjrqrqfqcqzqsqcnqhfgsclfnfzblfdhphrvqdpvcqmllrcdnrlwqbrgqsbfqqllcvmglntjwcsjljgntmmldscndfdjcqpwbqpbmfjsgwfwcqbqbbhhgprlbzmvdfjcsmsqvhfhmgrhnwpslztmwbhdgrfzfcmwjswpbpzwstfbfmgwtprmptzjwtrqthrqwgslnmtlfgnvgpwvsfwthtrgwfbnnnwmdcfrpqqztplscvfnfpfwwdnfnzjccnhswwlcrrdqfhvsrnvcdrwmjswzggscplggbwgndsbntqvtrjbmbzrnbbmdjvwrmmtrmfjjhnvrcjcbqlhlthbvtjjczddblbbttmmzgdqmtdqswjdwbjhsrjbvdtqzqdbhhgbttgmgwfgfpczpqpfsddgslltwsvngwbwfbfcdzlqghwdbfzzldjpwpmpjmslwnwbrjjvwcsjgdzjwrrwnvgvrqlgjhwvrgnczspfplhfbtdpbpfqmhbvmcqdgrrjfslzgsqfpwrrrmjdtgbslddwvddrbmrdsdhhnlwsncrmnglrrpvtbrfvjbdmcpgphcdfwnfcglvmlbslttpmjnspqhnmbcqgmncfjjpdfjqhggnswbgppjhllscrvtmtmmbwbpgddtzblscntrmccdpzdnllqpvfdpfpwwvnnbjlzphvqwffwsjmbtllctrjmllwscmldcdrpfrzrqlpwbjwfgmnshzqzgdjqhcwtsqlsjffvzcpnrzmvtlzlgwvrrjtdbcnddbhjgqqzrvhplrbsrwgscjnfmhbcnpdcjqrltgdzzzzbqtsspbcdssbjrzfqdgvhmgdzsjdsqcfwbgrnhrlzgpjmhctqdccmvqzddmcptsjgtfshprqmslvtmtrprfsngrnnpnrccrvnrvcwzrbbnbghlwvcncgzglnqthchhsnzlfrcggdptvwlrbnfwgjpflgrcfzhhgffwcbhwlsdmvmsvvzvdcrlvlnstgz";
        }

        static bool HaveSignal(Dictionary<char, int> recent)
        {
            return recent.Count == SignalLength;
        }
    }
}