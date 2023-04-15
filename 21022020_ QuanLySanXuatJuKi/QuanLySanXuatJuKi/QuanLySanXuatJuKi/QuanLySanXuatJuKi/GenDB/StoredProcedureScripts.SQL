DROP procedure IF EXISTS `spBangnhapsolop_Select`;

DELIMITER $$
CREATE    PROCEDURE `spBangnhapsolop_Select` (IN id VARCHAR(100) , IN fields BLOB)
BEGIN
    SET @s = CONCAT('SELECT ',fields,' FROM `Bangnhapsolop` WHERE `MaBarCodeSanPham`=''', id, ''';' );
    PREPARE stmt FROM @s;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
END
$$

DELIMITER ;

DROP procedure IF EXISTS `spBangnhapsolop_Insert`;

DELIMITER $$

CREATE    PROCEDURE `spBangnhapsolop_Insert`
    (
     IN val1 INT(11) ,
     IN val2 INT(11) ,
     IN val3 INT(11) ,
     IN val4 INT(11) ,
     IN val5 INT(11) ,
     IN val6 INT(11) ,
     IN val7 INT(11) ,
     IN val8 INT(11) ,
     IN val9 INT(11) ,
     IN val10 VARCHAR(100) ,
     IN val11 VARCHAR(100) ,
     IN val12 INT(11) ,
     IN val13 VARCHAR(100) ,
     IN val14 VARCHAR(100) ,
     IN val15 INT(11) ,
     IN val16 INT(11) ,
     IN val17 INT(11) ,
     IN val18 INT(11) ,
     IN val19 INT(11)
    )
BEGIN
    INSERT  INTO  `Bangnhapsolop`
            ( `CatL01` ,
              `CatL02` ,
              `CatL03` ,
              `CatL04` ,
              `CatL05` ,
              `CatL06` ,
              `CatL07` ,
              `CatL08` ,
              `CatL09` ,
              `LopNhung` ,
              `MaBarCodeSanPham` ,
              `SIRU` ,
              `TenSanPhamTiengAnh` ,
              `TenSanPhamTiengViet` ,
              `TongLopNhung` ,
              `Zircon01` ,
              `Zircon02` ,
              `Zircon03` ,
              `Zircon04`
            )
    VALUES  ( val1 ,
               val2 ,
               val3 ,
               val4 ,
               val5 ,
               val6 ,
               val7 ,
               val8 ,
               val9 ,
               val10 ,
               val11 ,
               val12 ,
               val13 ,
               val14 ,
               val15 ,
               val16 ,
               val17 ,
               val18 ,
               val19
            );
    SELECT  LAST_INSERT_ID();

END
$$

DELIMITER ;


DROP procedure IF EXISTS `spBangnhapsolop_Update`;

DELIMITER $$

CREATE    PROCEDURE `spBangnhapsolop_Update` (
     IN val1 INT(11) ,
     IN val2 INT(11) ,
     IN val3 INT(11) ,
     IN val4 INT(11) ,
     IN val5 INT(11) ,
     IN val6 INT(11) ,
     IN val7 INT(11) ,
     IN val8 INT(11) ,
     IN val9 INT(11) ,
     IN val10 VARCHAR(100) ,
     IN val11 VARCHAR(100) ,
     IN val12 INT(11) ,
     IN val13 VARCHAR(100) ,
     IN val14 VARCHAR(100) ,
     IN val15 INT(11) ,
     IN val16 INT(11) ,
     IN val17 INT(11) ,
     IN val18 INT(11) ,
     IN val19 INT(11) ,
     val20 VARCHAR(100)
    )
BEGIN
    UPDATE  `Bangnhapsolop`
    SET     `CatL01`=val1,
            `CatL02`=val2,
            `CatL03`=val3,
            `CatL04`=val4,
            `CatL05`=val5,
            `CatL06`=val6,
            `CatL07`=val7,
            `CatL08`=val8,
            `CatL09`=val9,
            `LopNhung`=val10,
            `MaBarCodeSanPham`=val11,
            `SIRU`=val12,
            `TenSanPhamTiengAnh`=val13,
            `TenSanPhamTiengViet`=val14,
            `TongLopNhung`=val15,
            `Zircon01`=val16,
            `Zircon02`=val17,
            `Zircon03`=val18,
            `Zircon04`=val19    WHERE   `MaBarCodeSanPham`=val20;
END
$$

DELIMITER ;


DROP procedure IF EXISTS `spBangnhapsolop_Delete`;

DELIMITER $$
CREATE    PROCEDURE `spBangnhapsolop_Delete` ( val1 VARCHAR(100) )
BEGIN
    DELETE FROM `Bangnhapsolop` WHERE `MaBarCodeSanPham`=val1;
END
$$

DELIMITER ;


DROP procedure IF EXISTS `spBangnhapsolop_GetAll`;

DELIMITER $$
CREATE PROCEDURE `spBangnhapsolop_GetAll` ()
BEGIN
    SELECT * FROM `Bangnhapsolop`;
END
$$

DELIMITER ;


DROP procedure IF EXISTS `spDulieuvabaocao_Select`;

DELIMITER $$
CREATE    PROCEDURE `spDulieuvabaocao_Select` (IN id INT(11) , IN fields BLOB)
BEGIN
    SET @s = CONCAT('SELECT ',fields,' FROM `Dulieuvabaocao` WHERE `id`=', id, ';' );
    PREPARE stmt FROM @s;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
END
$$

DELIMITER ;

DROP procedure IF EXISTS `spDulieuvabaocao_Insert`;

DELIMITER $$

CREATE    PROCEDURE `spDulieuvabaocao_Insert`
    (
     IN val1 VARCHAR(1000) ,
     IN val2 VARCHAR(100) ,
     IN val3 VARCHAR(100) ,
     IN val4 VARCHAR(100) ,
     IN val5 VARCHAR(1000) ,
     IN val6 INT(11) ,
     IN val7 INT(11) ,
     IN val8 INT(11) ,
     IN val9 VARCHAR(100) ,
     IN val10 VARCHAR(100) ,
     IN val11 VARCHAR(100) ,
     IN val12 VARCHAR(100) ,
     IN val13 DATETIME ,
     IN val14 DATETIME ,
     IN val15 DATETIME ,
     IN val16 DATETIME ,
     IN val17 VARCHAR(100)
    )
BEGIN
    INSERT  INTO  `Dulieuvabaocao`
            ( `MaBarCodeCot` ,
              `MaBarCodeLot` ,
              `MaBarCodeNguoi` ,
              `MaBarCodeSanPham` ,
              `MaBarCodeXe` ,
              `SoLopHienTai` ,
              `SoLopKetThuc` ,
              `SoThoiGianKho` ,
              `TenCatNhungHienTai` ,
              `TenCatNhungTiepTheo` ,
              `TenSanPhamTiengAnh` ,
              `TenSanPhamTiengViet` ,
              `ThoiGianBatDauNhung` ,
              `ThoiGianBatDauPhoi` ,
              `ThoiGianKetThucKho` ,
              `ThoiGianKetThucQuaTrinh` ,
              `TrangThaiDen`
            )
    VALUES  ( val1 ,
               val2 ,
               val3 ,
               val4 ,
               val5 ,
               val6 ,
               val7 ,
               val8 ,
               val9 ,
               val10 ,
               val11 ,
               val12 ,
               val13 ,
               val14 ,
               val15 ,
               val16 ,
               val17
            );
    SELECT  LAST_INSERT_ID();

END
$$

DELIMITER ;


DROP procedure IF EXISTS `spDulieuvabaocao_Update`;

DELIMITER $$

CREATE    PROCEDURE `spDulieuvabaocao_Update` (
     IN val1 VARCHAR(1000) ,
     IN val2 VARCHAR(100) ,
     IN val3 VARCHAR(100) ,
     IN val4 VARCHAR(100) ,
     IN val5 VARCHAR(1000) ,
     IN val6 INT(11) ,
     IN val7 INT(11) ,
     IN val8 INT(11) ,
     IN val9 VARCHAR(100) ,
     IN val10 VARCHAR(100) ,
     IN val11 VARCHAR(100) ,
     IN val12 VARCHAR(100) ,
     IN val13 DATETIME ,
     IN val14 DATETIME ,
     IN val15 DATETIME ,
     IN val16 DATETIME ,
     IN val17 VARCHAR(100) ,
     val18 INT(11)
    )
BEGIN
    UPDATE  `Dulieuvabaocao`
    SET     `MaBarCodeCot`=val1,
            `MaBarCodeLot`=val2,
            `MaBarCodeNguoi`=val3,
            `MaBarCodeSanPham`=val4,
            `MaBarCodeXe`=val5,
            `SoLopHienTai`=val6,
            `SoLopKetThuc`=val7,
            `SoThoiGianKho`=val8,
            `TenCatNhungHienTai`=val9,
            `TenCatNhungTiepTheo`=val10,
            `TenSanPhamTiengAnh`=val11,
            `TenSanPhamTiengViet`=val12,
            `ThoiGianBatDauNhung`=val13,
            `ThoiGianBatDauPhoi`=val14,
            `ThoiGianKetThucKho`=val15,
            `ThoiGianKetThucQuaTrinh`=val16,
            `TrangThaiDen`=val17    WHERE   `id`=val18;
END
$$

DELIMITER ;


DROP procedure IF EXISTS `spDulieuvabaocao_Delete`;

DELIMITER $$
CREATE    PROCEDURE `spDulieuvabaocao_Delete` ( val1 INT(11) )
BEGIN
    DELETE FROM `Dulieuvabaocao` WHERE `id`=val1;
END
$$

DELIMITER ;


DROP procedure IF EXISTS `spDulieuvabaocao_GetAll`;

DELIMITER $$
CREATE PROCEDURE `spDulieuvabaocao_GetAll` ()
BEGIN
    SELECT * FROM `Dulieuvabaocao`;
END
$$

DELIMITER ;


DROP procedure IF EXISTS `spMabarcode_Select`;

DELIMITER $$
CREATE    PROCEDURE `spMabarcode_Select` (IN id INT(11) , IN fields BLOB)
BEGIN
    SET @s = CONCAT('SELECT ',fields,' FROM `Mabarcode` WHERE `id`=', id, ';' );
    PREPARE stmt FROM @s;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
END
$$

DELIMITER ;

DROP procedure IF EXISTS `spMabarcode_Insert`;

DELIMITER $$

CREATE    PROCEDURE `spMabarcode_Insert`
    (
     IN val1 VARCHAR(1000) ,
     IN val2 VARCHAR(100) ,
     IN val3 VARCHAR(100) ,
     IN val4 VARCHAR(100) ,
     IN val5 VARCHAR(1000) ,
     IN val6 VARCHAR(100)
    )
BEGIN
    INSERT  INTO  `Mabarcode`
            ( `MaBarCodeCot` ,
              `MaBarCodeLot` ,
              `MaBarCodeNguoi` ,
              `MaBarCodeSanPham` ,
              `MaBarCodeXe` ,
              `TrangThai`
            )
    VALUES  ( val1 ,
               val2 ,
               val3 ,
               val4 ,
               val5 ,
               val6
            );
    SELECT  LAST_INSERT_ID();

END
$$

DELIMITER ;


DROP procedure IF EXISTS `spMabarcode_Update`;

DELIMITER $$

CREATE    PROCEDURE `spMabarcode_Update` (
     IN val1 VARCHAR(1000) ,
     IN val2 VARCHAR(100) ,
     IN val3 VARCHAR(100) ,
     IN val4 VARCHAR(100) ,
     IN val5 VARCHAR(1000) ,
     IN val6 VARCHAR(100) ,
     val7 INT(11)
    )
BEGIN
    UPDATE  `Mabarcode`
    SET     `MaBarCodeCot`=val1,
            `MaBarCodeLot`=val2,
            `MaBarCodeNguoi`=val3,
            `MaBarCodeSanPham`=val4,
            `MaBarCodeXe`=val5,
            `TrangThai`=val6    WHERE   `id`=val7;
END
$$

DELIMITER ;


DROP procedure IF EXISTS `spMabarcode_Delete`;

DELIMITER $$
CREATE    PROCEDURE `spMabarcode_Delete` ( val1 INT(11) )
BEGIN
    DELETE FROM `Mabarcode` WHERE `id`=val1;
END
$$

DELIMITER ;


DROP procedure IF EXISTS `spMabarcode_GetAll`;

DELIMITER $$
CREATE PROCEDURE `spMabarcode_GetAll` ()
BEGIN
    SELECT * FROM `Mabarcode`;
END
$$

DELIMITER ;


