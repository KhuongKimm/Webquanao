mapboxgl.accessToken = 'pk.eyJ1IjoiaGllcDAwIiwiYSI6ImNsMGM5a2ltZjE0dXEzY3Fza3FmNWd5bXgifQ.gBIjy4cd-a_sKqCtYErvkw';
const map = new mapboxgl.Map({
    container: 'map', // container ID
    style: 'mapbox://styles/hiep00/cl1unxd3f000l15o9m7m5rgfs', // style URL
    center: [105.85, 21.0], // starting position [lng, lat]
    zoom: 15 // starting zoom
});
var marker = new mapboxgl.Marker({
    color: "red", //Màu của Marker là đỏ
    draggable: true,
    anchor: 'bottom', //Nhãn HàNội nằm dưới Marker
}).setLngLat([105.85, 21.0]).addTo(map); //Thiết lập Marker tại hàNội


var popup = new mapboxgl.Popup({
    closeButton: true,
    closeOnClick: false,
    anchor: 'right',
}).setLngLat([105.85, 21.0]).setHTML("<p> My Store </p>").addTo(map);
map.addControl(new mapboxgl.NavigationControl({
    showCompass: true,
    showZoom: true,
}));
map.addControl(new mapboxgl.GeolocateControl({
    positionOptions: {
        enableHighAccuracy: true
    },
    trackUserLocation: true
}));

var scale = new mapboxgl.ScaleControl({
    maxWidth: 80,
    unit: 'imperial'
});
map.addControl(scale);
scale.setUnit('metric');

map.once('click', function (e) {
    map.addControl(new MapboxDirections({
        accessToken: mapboxgl.accessToken,
        setLngLat: ([105.85, 21.0])
    }), 'top-left');
    var popup = new mapboxgl.Popup({
        closeButton: true,
        closeOnClick: true,
    })
        .setLngLat([105.85, 21.0])
        .addTo(map);
});

map.addControl(new mapboxgl.FullscreenControl());
// Vídụ1: Sựkiện khi người dùng Click trên bản đồsẽhiện lên một Popup hiển thịkinh độ, vĩđộtại vịtríNhấn:
map.on('click', function (e) {
    var popup = new mapboxgl.Popup({
        closeButton: true,
        closeOnClick: true,
    })
        .setLngLat([e.lngLat.lng, e.lngLat.lat])
        /* .setHTML("<p> Vị trí chọn là: " + e.lngLat + "<p>")*/
        .addTo(map);
});

// Vídụ2: Tạo một marker màu xanh blue tại vịtrínhấn đúp chuột trên bản đồ.
map.on('dblclick', function (e) {
    new mapboxgl.Marker({
        color: 'blue',
        draggable: true,
    }).setLngLat([e.lngLat.lng, e.lngLat.lat]).addTo(map);
});