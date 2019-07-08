
var baseMapLayer = new ol.layer.Tile({
    source: new ol.source.OSM()
});
var map = new ol.Map({
    target: 'map',
    layers: [baseMapLayer],
    view: new ol.View({
        center: ol.proj.fromLonLat([-9.294444444, 38.70833333]), // Cordinates of EDISOFT
        zoom: 7 //Initial Zoom Level
    })
});

//Adding a marker on the map

var marker1 = new ol.Feature({
    geometry: new ol.geom.Point(
        ol.proj.fromLonLat([-9.294444444, 37.70833333])
    ),  // Cordinates of EDISOFT Thales in Paço de Arcos
});

marker1.setStyle(new ol.style.Style({
    image: new ol.style.Icon(({
        crossOrigin: 'anonymous',
        src: 'AISSymbols/cargo-ship.png',
        scale: 0.30

    }))
}));

var marker2 = new ol.Feature({
    geometry: new ol.geom.Point(
        ol.proj.fromLonLat([-9.294444444, 38.70833333])
    ),  // Cordinates of 1 degree to the west of EDISOFT location
});
marker2.setStyle(new ol.style.Style({
    image: new ol.style.Icon(({
        crossOrigin:
            'anonymous',
        src: 'AISSymbols/AIS_Vessel.svg',
        rotation: Math.PI / 4.0,
        scale: 0.30

    }))
}));

var vectorSource = new ol.source.Vector({
    features: [marker1, marker2]
});

var markerVectorLayer = new ol.layer.Vector({
    source: vectorSource,

});
map.addLayer(markerVectorLayer);

var marker = new ol.Feature({
    geometry: new ol.geom.Point(
        ol.proj.fromLonLat([-9.294444444, 38.70833333])
    ),  // Cordinates of New York's City Hall
});



