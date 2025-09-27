K58KTP - Môn: Phát triển ứng dụng trên nền web

Sinh viên thực hiện : Lăng Nguyễn Minh Lượng MSSV:K225480106044

BÀI TẬP VỀ NHÀ 01:

TẠO SOLUTION GỒM CÁC PROJECT SAU:

DLL đa năng, keyword: c# window library -> Class Library (.NET Framework) bắt buộc sử dụng .NET Framework 2.0: giải bài toán bất kỳ, độc lạ càng tốt, phải có dấu ấn cá nhân trong kết quả, biên dịch ra DLL. DLL độc lập vì nó ko nhập, ko xuất, nó nhận input truyền vào thuộc tính của nó, và trả về dữ liệu thông qua thuộc tính khác, hoặc thông qua giá trị trả về của hàm. Nó độc lập thì sẽ sử dụng được trên app dạng console (giao diện dòng lệnh - đen sì), cũng sử dụng được trên app desktop (dạng cửa sổ), và cũng sử dụng được trên web form (web chạy qua iis).

Console app, bắt buộc sử dụng .NET Framework 2.0, sử dụng được DLL trên: nhập được input, gọi DLL, hiển thị kết quả, phải có dấu án cá nhân. keyword: c# window Console => Console App (.NET Framework), biên dịch ra EXE

Windows Form Application, bắt buộc sử dụng .NET Framework 2.0**, sử dụng được DLL đa năng trên, kéo các control vào để có thể lấy đc input, gọi DLL truyền input để lấy đc kq, hiển thị kq ra window form, phải có dấu án cá nhân; keyword: c# window Desktop => Windows Form Application (.NET Framework), biên dịch ra EXE

Web đơn giản, bắt buộc sử dụng .NET Framework 2.0, sử dụng web server là IIS, dùng file hosts để tự tạo domain, gắn domain này vào iis, file index.html có sử dụng html css js để xây dựng giao diện nhập được các input cho bài toán, dùng mã js để tiền xử lý dữ liệu, js để gửi lên backend. backend là api.aspx, trong code của api.aspx.cs thì lấy được các input mà js gửi lên, rồi sử dụng được DLL đa năng trên. kết quả gửi lại json cho client, js phía client sẽ nhận được json này hậu xử lý để thay đổi giao diện theo dữ liệu nhận dược, phải có dấu án cá nhân. keyword: c# window web => ASP.NET Web Application (.NET Framework) + tham khảo link chatgpt thầy gửi. project web này biên dịch ra DLL, phải kết hợp với IIS mới chạy được.
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Bài làm 

Đề tài : Máy tinh BMI

1. Tạo SOLUTION sau đó add các project :

-thư viện library: UniversalHealthToolkit

-console: Bmiconsole

-winforms: Bmidesktop

-webforms:Bmiweb


<img width="332" height="266" alt="image" src="https://github.com/user-attachments/assets/e9d35292-1af3-46f2-9e52-494aa03091d9" />


2.Chạy thử console 

 
<img width="1365" height="767" alt="image" src="https://github.com/user-attachments/assets/23f4418b-243f-4214-b589-07e587efed67" />


3.Chạy thử Winforms


<img width="1271" height="667" alt="image" src="https://github.com/user-attachments/assets/5583ed0d-4212-4a83-bf71-3b9e94d13a96" />


4.Chạy thử webforms


<img width="884" height="725" alt="image" src="https://github.com/user-attachments/assets/69cfa0bf-63bf-4550-a033-67e8497fe2c2" />

