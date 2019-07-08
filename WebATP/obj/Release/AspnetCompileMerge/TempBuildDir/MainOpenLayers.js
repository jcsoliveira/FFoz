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


var aisMarkerFeatures = [];
var vectorSource = new ol.source.Vector({
    features: aisMarkerFeatures //add an array of features
});
var vectorLayer = new ol.layer.Vector({
    source: vectorSource
});


map.addLayer(vectorLayer);




function addMarker(MMSI, lon, lat, COG) {

    var found = false;

    for(var i = 0; i < aisMarkerFeatures.length; i++) {
        if (aisMarkerFeatures[i].getId() === MMSI) {
            aisMarkerFeatures[i].set('geometry', new ol.geom.Point(getPointFromLongLat(parseFloat(lon), parseFloat(lat))));
            aisMarkerFeatures[i].setStyle(new ol.style.Style({
                image: new ol.style.Icon(({
                    crossOrigin:
                        'anonymous',
                    src: 'AISMarkers/cargo-ship.png',
                    rotation: Math.PI * parseFloat(COG) / 180.0,
                    scale: 0.30
                })),
                text: new ol.style.Text({
                    text: MMSI.toString(),
                    fill: new ol.style.Fill({ color: 'black' }),
                    stroke: new ol.style.Stroke({ color: 'black', width: 1 }),
                    offsetX: -20,
                    offsetY: 20
                })
            }));
            found = true;
            break;
        }
    }
    if (found == false) {
        var markerGeometry = new ol.geom.Point(ol.proj.fromLonLat([parseFloat(lon), parseFloat(lat)]));
        var markerFeature = new ol.Feature({
            geometry: markerGeometry
        });

        markerFeature.setId(MMSI);

        markerFeature.setStyle(new ol.style.Style({
            image: new ol.style.Icon(({
                crossOrigin:
                    'anonymous',
                src: 'AISMarkers/cargo-ship.png',
                rotation: Math.PI * parseFloat(COG) / 180.0,
                scale: 0.30
            })),
            text: new ol.style.Text({
                text: MMSI.toString(),
                fill: new ol.style.Fill({ color: 'black' }),
                stroke: new ol.style.Stroke({ color: 'black', width: 1 }),
                offsetX: -20,
                offsetY: 20
            })
        }));
        aisMarkerFeatures.push(markerFeature);
    }


};

function getPointFromLongLat(long, lat) {
    return ol.proj.transform([long, lat], 'EPSG:4326', 'EPSG:3857')
}


window.setInterval(function () {

    //clean the layer from any existing markers
    vectorSource.clear(true);

    $.ajax({
        url: 'http://localhost/aisdataretriever/aisdataretriever.asmx/TransferAISPosition',
        type: 'POST',
        cache: false,
        dataType: 'json',
        success: function (aisdata) {
            $.each(aisdata, function (recordCount, aisship) {


                var createMarker = addMarker(aisship.MMSI, aisship.Longitude, aisship.Latitude, aisship.COG);

            });
            //and here add the newly created features to the layer
            vectorSource.addFeatures(aisMarkerFeatures);
            vectorSource.refresh();

        }, error: function () {
            console.log("Connection Failed");
        }
    });
}, 4000);