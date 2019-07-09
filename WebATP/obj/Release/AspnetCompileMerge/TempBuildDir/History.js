var historyMarkerFeatures = [];

var vectorHistoryRotation;

var historyMap

function initHistory(map) {
    historyMap = map;
}

function reloadHistory() {
    var vectorSource = new ol.source.Vector({
        features: historyMarkerFeatures,
        strategy: ol.loadingstrategy.bbox
    })

    var markerVectorLayer = new ol.layer.Vector({
        source: vectorSource,

    });

    historyMap.addLayer(markerVectorLayer);

    vectorSource.once('change', function () {
        console.log('refresh history layer')
        if (vectorHistoryRotation) {
            historyMap.removeLayer(vectorHistoryRotation);
        }
        vectorHistoryRotation = markerVectorLayer;
    });
}

function addMarkerHistory(recordCount, MMSI, longitude, latitude) {
    if (parseFloat(longitude) >= -180.0 && parseFloat(longitude) <= 180.0
        && parseFloat(latitude) >= -90.0 && parseFloat(latitude) <= 90.0) {

        var markerX = new ol.Feature({
            geometry: new ol.geom.Point(ol.proj.fromLonLat([parseFloat(longitude), parseFloat(latitude)]))
        });
        markerX.setStyle(new ol.style.Style({
            image: new ol.style.Icon({
                crossOrigin:
                    'anonymous',
                src: 'AISMarkers/AIS_VesselHistory.svg',
                scale: 0.30
            })
        }));
        markerX.setId(MMSI + 1000000000 * (recordCount+1));
        historyMarkerFeatures.push(markerX);
    }

}

function DisplayTrackHistory(MMSI) {

    var today = new Date();
    var one_day_ago = new Date(new Date().setDate(today.getDate() - 5));

    $.ajax({
        url: 'http://localhost/AISDataretriever/AISDataretriever.asmx/TransferShipHistory',
        data: "MMSI=" + MMSI + "&startTime=" + one_day_ago.toISOString() + "&endTime=" + today.toISOString(),
        type: 'POST',
        cache: false,
        dataType: 'json',
        success: function (aisdata) {
            for (const [recordCount, aisship] of aisdata.entries()) {
                var createMarker = addMarkerHistory(recordCount, aisship.MMSI, aisship.Longitude, aisship.Latitude);
            }
            reloadHistory();
        }, error: function () {
            console.log("Connection Failed");
        }
    });
}