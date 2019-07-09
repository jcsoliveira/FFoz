

var baseMapLayer = new ol.layer.Tile({
    source: new ol.source.OSM(),
    opaque: false
});

var container = document.getElementById('popup');
var content = document.getElementById('popup-content');
var closer = document.getElementById('popup-closer');

/**
 * Create an overlay to anchor the popup to the map.
 */
var overlay = new ol.Overlay({
    element: container,
    autoPan: true
});

/**
 * Add a click handler to hide the popup.
 * @return {boolean} Don't follow the href.
 */
closer.onclick = function () {
    overlay.setPosition(undefined);
    closer.blur();
    return false;
};


var mousePositionControl = new ol.control.MousePosition({
    coordinateFormat: ol.coordinate.createStringXY(4),
    projection: 'EPSG:4326',
    // comment the following two lines to have the mouse position
    // be placed within the map.
    className: 'custom-mouse-position',
    target: document.getElementById('mouse-position'),
    undefinedHTML: '&nbsp;'
});


var openSeaMapLayer = new ol.layer.Tile({
    source: new ol.source.XYZ({
        url: 'http://t1.openseamap.org/seamark/{z}/{x}/{y}.png'
        //,crossOrigin: 'null'
    })
});


var map = new ol.Map({
    target: 'map',
    layers: [baseMapLayer
        , openSeaMapLayer
    ],
    view: new ol.View({
        center: ol.proj.fromLonLat([-9.294444444, 38.70833333]), // Cordinates of EDISOFT
        zoom: 7 //Initial Zoom Level
    }),

    overlays: [overlay
    ]
    /*    target: 'map',
   view: new ol.View({
        center: [0, 0],
        zoom: 2
    })*/
});

//call to initiate the history layer to the map
initHistory(map);

//var intervalId;
map.on("click", function (event) {
    if (aisDataWindowActive == false) {
//        intervalId = window.setInterval(function () {
            map.forEachFeatureAtPixel(event.pixel, function (feature, layer) {
                //do something
                //based on the featureID get the data of the ship from database and display: position, COG,SPEED, Heading,etc
                if (feature.getId() == "IND") {
                }

                $.ajax({
                    url: 'http://localhost/AISDataretriever/AISDataretriever.asmx/TransferShipVoyageData',
                    data: "MMSI=" + feature.getId(),
                    type: 'POST',
                    cache: false,
                    dataType: 'json',
                    success: function (aisdata) {
                        var longitude = aisdata.Longitude;
                        var latitude = aisdata.Latitude;
                        var MMSI = aisdata.MMSI;
                        var sog = aisdata.SOG;
                        var cog = aisdata.COG;
                        var heading = aisdata.heading == 511 ? '---' : aisdata.heading;
                        var messTime = aisdata.Mess_time;
                        var shipType = aisdata.Type;
                        var IMO_number = aisdata.IMO_number;
                        var callSign = aisdata.Call_sign;
                        var name = aisdata.Name;
                        var shipLength = aisdata.length;
                        var shipWidth = aisdata.width;
                        var shipDraught = aisdata.draught;
                        var ETA = aisdata.ETA;
                        var destination = aisdata.Destination;
                        var coordinate = [Number(longitude), Number(latitude)];
                        var hdms = ol.coordinate.toStringHDMS(coordinate);


                        content.innerHTML =
                            '<b>Ship name:</b> ' + name + ' <b>MMSI:</b> ' + MMSI + '<br>'
                            + '<b>Ship type:</b> ' + shipType + ' <b>IMO:</b> ' + IMO_number + ' <b>Callsign:</b> ' + callSign + '<br>'
                            + '<b>Position:</b> ' + hdms + ' <b>Update time:</b> ' + messTime + '<br>'
                            + '<b>Speed:</b> ' + sog + ' <b>Course:</b> ' + cog + ' <b>heading:</b> ' + heading + '<br>'
                            + '<b>Length:</b> ' + shipLength + ' <b>Width:</b> ' + shipWidth + ' <b>Draught:</b> ' + shipDraught + '<br>'
                            + '<b>Voyage Destination:</b> ' + destination + ' <b>ETA:<b> ' + ETA
                            ;

                        var projectionCoord = ol.proj.transform(coordinate, 'EPSG:4326', 'EPSG:3857');
                        overlay.setPosition(projectionCoord);
                        aisDataWindowActive = true;
                        window.open("TrackDetailsWebForm.aspx?MMSI=" + MMSI);
                    }, error: function () {
                        console.log("Connection Failed");
                    }
                });

/*
                $.ajax({
                    url: "TrackDetailsWebForm.aspx",
                    data: "MMSI=" + feature.getId(),
                    type: 'POST',
                    cache: false,
                    dataType: 'json',
                    success: function (aisdata) {
                        alert('Ok! It worked.');


                    }, error: function () {
                        console.log("Connection Failed");
                    }
                });
*/
 


                /*********************************************************************
                 * Temporarylly  place where ithe call for history display of the selected track
                 * 
                 */
                DisplayTrackHistory(feature.getId(), map);


                /*
                        console.log("cliquei na posicao: no navio com MMSI= " + feature.getId());
                
                        var coordinate = event.coordinate;
                        var hdms = ol.coordinate.toStringHDMS(ol.proj.transform(
                            coordinate, 'EPSG:3857', 'EPSG:4326'));
                
                        content.innerHTML = '<p>You clicked here:</p><code>' + hdms +
                            '</code>';
                        overlay.setPosition(coordinate);
                */
            });
            console.log('refresh AIS data overlay')
 //       }, 1000);
    } else {
        alert('An AIS data Window is open. To see this AIS data, close the other first')
    }
});


var aisDataWindowActive = false;
$('a').click(function (e) {
    e.preventDefault();
    //window.clearInterval(intervalId);
    aisDataWindowActive = false;

    return false;
});


map.addControl(mousePositionControl);

var myMarkerFeatures = [];

var vectorRotation;

function reload() {
    var vectorSource = new ol.source.Vector({
        features: myMarkerFeatures,
        strategy: ol.loadingstrategy.bbox
    })

    var markerVectorLayer = new ol.layer.Vector({
        source: vectorSource,

    });

    map.addLayer(markerVectorLayer);

    vectorSource.once('change', function () {
        console.log('refresh track layer')
        if (vectorRotation) {
            map.removeLayer(vectorRotation);
        }
        vectorRotation = markerVectorLayer;
    });
}

function checkHeading(heading) {
    var cleanedheading = 511;

    if (heading != 511) {
        cleanedheading = heading
    }
    while (cleanedheading != 511 && heading > 360) {
        heading -= 360;
    }
    return cleanedheading
}

function getshipIcon(Navstatus, shipType) {
    var shipIcon = 'AISMarkers/AIS_Vessel.svg';

    if (Navstatus == 7) {
        shipIcon = 'AISMarkers/FishingShip.svg';
    } else if (Navstatus == 9 || Navstatus == 10) {
        shipIcon = 'AISMarkers/myDangerousCargo.svg'
    }
    else {
        switch (shipType) {
            case 'WIG-Carrying DG, HS, or MP, IMO hazard or pollutant category A':
            case 'Vessel, Towing and length of the tow exceeds 200 mor breadth exceeds 25 m':
            case 'Carrying DG, HS, or MP, IMO hazard or pollutant category C':
            case 'Vessels with anti-pollution facilities or equipment':
                shipIcon = 'AISMarkers/myDangerousCargo.svg';
                break;
            case 'Fishing':
                shipIcon = 'AISMarkers/FishingShip.svg';
                break;
            case 'Cargo ships':
                shipIcon = 'AISMarkers/CargoShip.svg';
                break;
            case 'Engaged in military operations':
                shipIcon = 'AISMarkers/myDangerousCargo.svg';
                break;
            default:
                shipIcon = 'AISMarkers/AIS_Vessel.svg';
        }
    }

    return shipIcon
}

function addMarker(MMSI, Navstatus, longitude, latitude, cog, heading) {

    if (parseFloat(longitude) >= -180.0 && parseFloat(longitude) <= 180.0
        && parseFloat(latitude) >= -90.0 && parseFloat(latitude) <= 90.0) {
        /*
                            console.log("long: " + longitude);
                            console.log("lat: " + latitude);
                            console.log("MMSI: " + MMSI);
                            console.log("COG: " + cog);
                            console.log("Heading: " + heading);
        */
        var shipOrientation = checkHeading(parseInt(heading));
        if (shipOrientation == 511) {
            shipOrientation = parseFloat(cog);
        }

        var found = false;

        for (var i = 0; i < myMarkerFeatures.length; i++) {
            if (myMarkerFeatures[i].getId() === MMSI) {
                myMarkerFeatures[i].getGeometry().setCoordinates(ol.proj.transform([parseFloat(longitude), parseFloat(latitude)], 'EPSG:4326', 'EPSG:3857'));
                //get shiptype 

                $.ajax({
                    url: 'http://localhost/AISDataretriever/AISDataretriever.asmx/TransferShipVoyageData',
                    data: "MMSI=" + MMSI,
                    type: 'POST',
                    cache: false,
                    dataType: 'json',
                    success: function (ship) {
                        var shipIcon = getshipIcon(Navstatus, ship.Type);
                        myMarkerFeatures[i].setStyle(new ol.style.Style({
                            image: new ol.style.Icon(({
                                crossOrigin:
                                    'anonymous',
                                src: shipIcon,
                                rotation: Math.PI * shipOrientation / 180.0,
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
                    }, error: function () {
                        console.log("Connection Failed");
                    }
                });

                ////////////////

                found = true;
                break;
            }
        }

        if (found == false) {
            var markerX = new ol.Feature({
                geometry: new ol.geom.Point(
                    ol.proj.fromLonLat([parseFloat(longitude), parseFloat(latitude)])
                ),
            });
            //Get shiptype 
            $.ajax({
                url: 'http://localhost/AISDataretriever/AISDataretriever.asmx/TransferShipVoyageData',
                data: "MMSI=" + MMSI,
                type: 'POST',
                cache: false,
                dataType: 'json',
                success: function (ship) {
                    var shipIcon = getshipIcon(Navstatus, ship.Type);
                    markerX.setStyle(new ol.style.Style({
                        image: new ol.style.Icon(({
                            crossOrigin:
                                'anonymous',
                            src: shipIcon,
                            rotation: (Math.PI * shipOrientation) / 180.0,
                            scale: 0.30

                        })),
                        text: new ol.style.Text({
                            text: MMSI.toString(),
                            overflow: true, //Decluttering is used to avoid overlapping labels
                            fill: new ol.style.Fill({ color: 'black' }),
                            stroke: new ol.style.Stroke({ color: 'back', width: 1 }),
                            offsetX: -20,
                            offsetY: 20
                        })

                    }));
                    markerX.setId(MMSI);
                    myMarkerFeatures.push(markerX);
                }, error: function () {
                    console.log("Connection Failed");
                }
            });

            /*
                        if (recordCount == 4) {
                            break;
            
                        }
            */
        }
    };
}
//////////////////////////////////////////////////////////
window.setInterval(function () {
    //vectorSource.clear(true);
    $.ajax({
        url: 'http://localhost/aisdataretriever/aisdataretriever.asmx/TransferAISPosition',
        type: 'POST',
        cache: false,
        dataType: 'json',
        success: function (aisdata) {
            for (const [recordCount, aisship] of aisdata.entries()) {
                var createMarker = addMarker(aisship.MMSI, aisship.Navstatus, aisship.Longitude, aisship.Latitude, aisship.COG, aisship.heading);
            }
            reload();
        }, error: function () {
            console.log("Connection Failed");
        }
    })
}, 4000);

//////////////////////////////////////////////////////////






