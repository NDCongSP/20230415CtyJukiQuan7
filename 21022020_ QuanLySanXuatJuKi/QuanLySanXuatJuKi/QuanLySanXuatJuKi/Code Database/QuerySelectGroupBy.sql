use juki_giamsatthoigiankho;

drop table if exists temp1;
drop table if exists temp2;
create temporary table temp2 SELECT TenSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeSanPham,SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot,ThoiGianBatDauNhung,ThoiGianBatDauPhoi,ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh,
MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen
FROM dulieuvabaocao order by SoLopHienTai desc;
create temporary table temp1 select temp2.*, count(*) as SoHang  from temp2 group by MaBarCodeLot;
select * from temp1 where (SoHang < SoLopKetThuc or SoLopKetThuc is null);# and MaBarCodeLot = 'WP18562494';WP24804921