var view = new ol.View({ center: [0, 0], zoom: 2 }),
    vectorLayer = new ol.layer.Vector({ source: new ol.source.Vector() }),
    baseLayer = new ol.layer.Tile({ source: new ol.source.OSM() }),
    map = new ol.Map({
        target: 'map',
        view: view,
        layers: [baseLayer, vectorLayer]
    });

var pinIcon = 'https://cdn.jsdelivr.net/gh/jonataswalker/ol-contextmenu@604befc46d737d814505b5d90fc171932f747043/examples/img/pin_drop.png';
var centerIcon = 'https://cdn.jsdelivr.net/gh/jonataswalker/ol-contextmenu@604befc46d737d814505b5d90fc171932f747043/examples/img/center.png';
var listIcon = 'https://cdn.jsdelivr.net/gh/jonataswalker/ol-contextmenu@604befc46d737d814505b5d90fc171932f747043/examples/img/view_list.png';

var contextmenuItems = [
    {
        text: 'Center map here',
        classname: 'bold',
        icon: centerIcon,
        callback: center
    },
    {
        text: 'Some Actions',
        icon: listIcon,
        items: [
            {
                text: 'Center map here',
                icon: centerIcon,
                callback: center
            },
            {
                text: 'Add a Marker',
                icon: pinIcon,
                callback: marker
            }
        ]
    },
    {
        text: 'Add a Marker',
        icon: pinIcon,
        callback: marker
    },
    '-' // this is a separator
];

var contextmenu = new ContextMenu({
    width: 180,
    items: contextmenuItems
});
map.addControl(contextmenu);

var removeMarkerItem = {
    text: 'Remove this Marker',
    classname: 'marker',
    callback: removeMarker
};

contextmenu.on('open', function (evt) {
    var feature = map.forEachFeatureAtPixel(evt.pixel, ft => ft);

    if (feature && feature.get('type') === 'removable') {
        contextmenu.clear();
        removeMarkerItem.data = { marker: feature };
        contextmenu.push(removeMarkerItem);
    } else {
        contextmenu.clear();
        contextmenu.extend(contextmenuItems);
        contextmenu.extend(contextmenu.getDefaultItems());
    }
});

map.on('pointermove', function (e) {
    if (e.dragging) return;

    var pixel = map.getEventPixel(e.originalEvent);
    var hit = map.hasFeatureAtPixel(pixel);

    map.getTargetElement().style.cursor = hit ? 'pointer' : '';
});

// from https://github.com/DmitryBaranovskiy/raphael
function elastic(t) {
    return Math.pow(2, -10 * t) * Math.sin((t - 0.075) * (2 * Math.PI) / 0.3) + 1;
}

function center(obj) {
    view.animate({
        duration: 700,
        easing: elastic,
        center: obj.coordinate
    });
}

function removeMarker(obj) {
    vectorLayer.getSource().removeFeature(obj.data.marker);
}

function marker(obj) {
    var coord4326 = ol.proj.transform(obj.coordinate, 'EPSG:3857', 'EPSG:4326'),
        template = 'Coordinate is ({x} | {y})',
        iconStyle = new ol.style.Style({
            image: new ol.style.Icon({ scale: .6, src: pinIcon }),
            text: new ol.style.Text({
                offsetY: 25,
                text: ol.coordinate.format(coord4326, template, 2),
                font: '15px Open Sans,sans-serif',
                fill: new ol.style.Fill({ color: '#111' }),
                stroke: new ol.style.Stroke({ color: '#eee', width: 2 })
            })
        }),
        feature = new ol.Feature({
            type: 'removable',
            geometry: new ol.geom.Point(obj.coordinate)
        });

    feature.setStyle(iconStyle);
    vectorLayer.getSource().addFeature(feature);
}
