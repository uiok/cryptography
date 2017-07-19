using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace cryptography.Controllers
{
    public class HomeController : Controller
    {

        private string _publicKeyA = "<RSAKeyValue><Modulus>wOvEkC6oScs3MqeY+IJtULGZHY+ORHYI9F92R/JrP61eQp3+ihR4NJZ4FrrtyF4w61mlwmOgr5DEBJIw9od4UVmCpwGGSNGcIaVQUrTa+IKahCcl+if+EQ8sNzAufZGwDR10khaeW1GHzrZIoquMxYjOefk9DVYYlPuMaj4Lu5TQ3Ud3M/F0rx2ZIu6eDQ9dL3n/Ek5qV5+Wvm+4awncFZdvMKD58P6Ph1sBcXJHtz3NxzYzjsH/ns4/O5ipaD5C7Apss8QJ10aggIW4sx9iiiFHpK3QrjY74xSjEeWVJ/l7GrJArv4u3gqIzXqng5Rkie5v/H7Q27v819aVWK3upQ==</Modulus><Exponent>AQAB</Exponent><P>yFydCjvl9YUsKIicHGWlNB0twD+K6+9UlxV90geJqoNGBjp6TlaP1t9NjgBoKSAzgyXj/CQgEh3lIKNVGZaqeYX6t74QwPFwzoPtOxZqpBxFgphx4rIMflLxIJk4OWOHlCDgo/8MHPZWOM1YhETu8KBl4WF7a191OZLybMvQ1uk=</P><Q>9n4zM+FKPn+QRIKp1U7/h1UHZnBvHRhsXgjzGEijW01ku8Y+6p4NqqNQZcAvdg8CtIPkXmkJimQJekzUqaGqX1QBXOc84m1wdaEMd92ZhMxnYLcfjmViP1Fw04Aob95e18mDRrN4U7M/FkjGyDS6B5tnyva1KhFPr4fQpnOffF0=</Q><DP>K7WQiMACbapMtNcAf21pOdI3vd3e15ORd5g3p47/aFRU/Vzae6aEoJJ8X8MU9gvRUQX+E25qFKmy54jaMsfcjsA8rsLm8sB5JIRBR4efYgfM3i2Vgqfm89PySHNEgbiFxjnZ58zm/pZ6vs+FRO2o1pOXRjC29PiRISs+eZ+JAqk=</DP><DQ>8+i5HfMmlmWACmsJRyweqnm3EuTa7n2Gbh6I/lSSYPxaW3y2MU8o0ts76ROdY0NDOADy74EckbafskdogFqazi3AE4A1vRDyIVO1lL7Q9JmXChrqvOsRpvodnQvJ97ihPQIIRuO8g4ZxPMnS+bVDB9f9gtdROUlcAqNwEeWDwXk=</DQ><InverseQ>b2k6GvihU30UqN/zaPh/dXhKbpW+BgWoIXM7OUf5/TFYqACF5LLBALgmluBgMj4BxZj15qNnGyS53muWEYKvCGYbNl+NeuksvKNIHKB/qSX7jr3ghU6CVoUVpZykedME439pN42vBqi/XNxyGJowv/ruCYVwffhkguw/o9bA5k4=</InverseQ><D>A+Jk+qObdLu2sKdCU61pzsBHE7Rxmh9hSa0hYcxeMr6s7iNY8TlKL7VG4jhHZ0UkPLZ5OXtNjGaaPiuExY+PnkQZEH+qnA07+xgLw7qLlrza239sffqvqVkrm/0O0C1U60Xh54e09QqkqCAWwTW6JIdyY6JsNp6ttiEErP/zHW0vsktQI80ZnisAmwWLQM8W0uUchHBSZd89VFrqSSatc5JRxpKAc34I+cXy5sU95vOpWiejzd339huEc8nEfaFewIUEhCs7BkB0nI0RCydc0/G9JZ/Bk4521FByaInhzdspr2COzfUg9zsgzoUOBadbyFmHCIG6ij12BFTTLGrUSQ==</D></RSAKeyValue>";
        private string _privateKeyA = "<RSAKeyValue><Modulus>wOvEkC6oScs3MqeY+IJtULGZHY+ORHYI9F92R/JrP61eQp3+ihR4NJZ4FrrtyF4w61mlwmOgr5DEBJIw9od4UVmCpwGGSNGcIaVQUrTa+IKahCcl+if+EQ8sNzAufZGwDR10khaeW1GHzrZIoquMxYjOefk9DVYYlPuMaj4Lu5TQ3Ud3M/F0rx2ZIu6eDQ9dL3n/Ek5qV5+Wvm+4awncFZdvMKD58P6Ph1sBcXJHtz3NxzYzjsH/ns4/O5ipaD5C7Apss8QJ10aggIW4sx9iiiFHpK3QrjY74xSjEeWVJ/l7GrJArv4u3gqIzXqng5Rkie5v/H7Q27v819aVWK3upQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

        private string _publicKeyB = "<RSAKeyValue><Modulus>gwHec3ocM22xOozSadQ8qjApUvhOXZFxyGohfoaoOx+ghqfwoLRr7nA/SKieLR6Ji/P5yZQn/FgD7YozTUy18xSaIKANohZCTJJIFnnWIJUCosdC+X4gkBIJP+uVvPbw/Lo9HbAXj1H0CcUl+8b/+UqdK1vzI5CteiCuzrfRAZqS7gUI8jcWVO7FwkTSHHDH7TTR5AKAJyuYN4YoLQbFEbFepFR2sT46r5SuBCWenmIxvKLy3py1GHQvinIEoLVMnzJrJ0YkVOlxSvBn+Hn8Ru9l0fnUimsPLELnvlDOwbn2KMrAv8iQSdWREU83fVktU3mFYW1wH9SlA+oArpo0/w==</Modulus><Exponent>AQAB</Exponent><P>uOuK806U1UifUZlcbEP+NTR66srui4fB4NPTxzb5VARFUWAoFIMIOhPLNXVM9bISFu34XHK15HMij2WFnQm8mZOVW2dXjIs4zI4zbD459/RooMKja4TuAJT7lQoydM50k3bc+E/OfqPf4RVb4lKw6Xtp7o/crYMX7E91o9g/Mt0=</P><Q>tV024KtR7yc126rAqXwSsMQVwGzjpEq2EYWEuinCqEiUQvfFgJEKlleymr2IRZT1xv+Ku7GZDOtgExqoOLZ+V7D2k1NVCfNSiNxv7HeuEjlddgGBM16Zt4Ph47YjTjVjRYW60THS/I/IADTdhlicSkbL+TAZACD0EDPzQzPlA4s=</Q><DP>Wr70PDwm25e8301URqkDOdbcLxaRA5YGda9d8RgwOKOz5KA8avx2cBHAmiZLMxNEv03eoHeGfWpm3lnivNLHY9JB7E4Fb6nuoKtz3r2WsvCU27dIfP4J0e1KnLQZWKrsGGWvQIfhfNIsjodtxN3xhVKUBIdCsz9u4P+JanM3aF0=</DP><DQ>padifIt+5wXVd7LbDvM4zyQLChtrQaDL8+0UckW6eqLwaMqPJwNTvEaV6Ci903BfnUfDm/R3awmCU3DBvitR8x672Yz/23rYJBHUWRRndlXXO/Xb4OPDW4+mP6sZTFIPPm0LWhA8OlvJvgaLYC6HcoB/xjdcXnW69yG8S+GWiEk=</DQ><InverseQ>dhadi1tE8MdVA5/rkaKmmc3GcbuB9h2hJoSJlrc+VbbvoLO50H8r2gqg6olAu/j2IRx8bRhUmryp8UUfLT8wFHkojIQqEEA4NEM//qDhxajAWLyeDH7sZV1fnbg/TyN+U3nvBdJNzrjGoNqNJY1oIpgmtdS/Z6dgdZKCmeijcUM=</InverseQ><D>MVeFXLHrqDUS0M4UO/bLaIAeOFk8TsKGe+j5N4npF+eYEs9y8lwx4IrXUvrrJGxBevxHorQSAVl3FUL9goo3Z1flmw8dQ2Sl0OgxjYGS9A+bgAqTv5tREWIxqKkG6zaI2m8csK9PmFPSGdHute8kHtUK8DdAEq+dnwdrP4F9D2CKLFJtQ28hASxMQoudxp74YCdpR2YlA1nsSYuhLIWoK3dpArCnHgapjf6cygbAe7iSI0tImu3KH6EKMYkvrK149eIJr+9/u/MTBb6QVk7Yw8BKvZeFjxdGBxCnprIkoH5m5WxGsdqPdxx6/X1JudP3yc4RMy0Di5KuYEP/jzBo1Q==</D></RSAKeyValue>";
        private string _privateKeyB = "<RSAKeyValue><Modulus>gwHec3ocM22xOozSadQ8qjApUvhOXZFxyGohfoaoOx+ghqfwoLRr7nA/SKieLR6Ji/P5yZQn/FgD7YozTUy18xSaIKANohZCTJJIFnnWIJUCosdC+X4gkBIJP+uVvPbw/Lo9HbAXj1H0CcUl+8b/+UqdK1vzI5CteiCuzrfRAZqS7gUI8jcWVO7FwkTSHHDH7TTR5AKAJyuYN4YoLQbFEbFepFR2sT46r5SuBCWenmIxvKLy3py1GHQvinIEoLVMnzJrJ0YkVOlxSvBn+Hn8Ru9l0fnUimsPLELnvlDOwbn2KMrAv8iQSdWREU83fVktU3mFYW1wH9SlA+oArpo0/w==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

        public ActionResult Index()
        {
            KeyGenerater();

            return View();
        }

        public void KeyGenerater()
        {
            RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider(2048);
            ViewBag.publicKeyA = rsaProvider.ToXmlString(true);
            ViewBag.privateKeyA = rsaProvider.ToXmlString(false);

            rsaProvider = new RSACryptoServiceProvider(2048);
            ViewBag.publicKeyB = rsaProvider.ToXmlString(true);
            ViewBag.privateKeyB = rsaProvider.ToXmlString(false);
        }


        public string Encrypt(string targetData, string AppPublicKey)
        {
            // 建立 RSA 演算法物件的執行個體
            RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider();
            rsaProvider.FromXmlString(_publicKeyA);

            byte[] origionalData = Encoding.Default.GetBytes(targetData);
            byte[] targetData_encrypt = rsaProvider.Encrypt(origionalData, false);

            // 匯出金鑰組。 
            //RSAParameters publicKey = rsaProvider.ExportParameters(false);    //匯出金鑰，參數 false 表示不含私鑰。
            //RSAParameters privateKey = rsaProvider.ExportParameters(true);    //匯出金鑰
          
            return Convert.ToBase64String(targetData_encrypt);
           
        }

        public string Decrypt(string targetData, string AppPublicKey)
        {
            RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider(2048);

            rsaProvider.FromXmlString(_privateKeyA);//get server private key

            byte[] encryptedData = Convert.FromBase64String(targetData);

            byte[] decryptedData = rsaProvider.Decrypt(encryptedData, false);

            return Encoding.UTF8.GetString(decryptedData);
        
        }
    }
}
