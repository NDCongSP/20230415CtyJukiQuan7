use juki_giamsatthoigiankho;

drop table if exists temp1;

create temporary table temp1 SELECT MaBarCodeSanPham,TenSanPhamTiengAnh,TenSanPhamTiengViet,MaBarCodeLot,ThoiGianKetThucQuaTrinh,SoLopHienTai,SoLopKetThuc,TenCatNhungHienTai,ThoiGianBatDauNhung, 
TIMEDIFF(ThoiGianBatDauPhoi,ThoiGianBatDauNhung) as ThoiGianNhung,ThoiGianBatDauPhoi,MAKETIME(sothoigiankho,0,0) as SoThoiGianPhoiDat, TIMEDIFF(ThoiGianKetThucQuaTrinh,ThoiGianBatDauPhoi) as SoThoiGianPhoiThucTe,
MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TrangThaiDen
FROM dulieuvabaocao where MaBarCodeLot='WP18562617';

ALTER TABLE temp1 MODIFY SoThoiGianPhoiDat time;

select * from temp1;

SELECT MaBarCodeSanPham as MaSanPham,TenSanPhamTiengAnh,TenSanPhamTiengViet,MaBarCodeLot as MaLOT,ThoiGianKetThucQuaTrinh,SoLopHienTai,SoLopKetThuc,TenCatNhungHienTai TenCatNhung,ThoiGianBatDauNhung, " +
                TIMEDIFF(ThoiGianBatDauPhoi, ThoiGianBatDauNhung) as ThoiGianNhung,ThoiGianBatDauPhoi,MAKETIME(sothoigiankho, 0, 0) as ThoiGianPhoiCaiDat, TIMEDIFF(ThoiGianKetThucQuaTrinh, ThoiGianBatDauPhoi) as ThoiGianPhoiThucTe," +
                MaBarCodeXe as Xe,MaBarCodeCot as Cot,MaBarCodeNguoi as NhanVien,TrangThaiDen as TrangThai FROM dulieuvabaocao where MaBarCodeLot = 'WP18562617';
