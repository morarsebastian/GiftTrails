(function ($) {
    $(function () {

        var _$form = $('#TrailCreationForm');

        _$form.find('input:first').focus();

        _$form.validate();

        _$form.find('button[type=submit]')
            .click(function (e) {
                e.preventDefault();

                if (!_$form.valid()) {
                    return;
                }

                var input = _$form.serializeFormToObject();
                abp.services.app.trail.create(input)
                    .done(function () {
                        location.href = '/Trails?giftId=' + input.GiftId;
                    });
            });
    });
})(jQuery);

function initAutocomplete() {
    //var map = new google.maps.Map(document.getElementById('dvMap'), {
    //    center: { lat: -33.8688, lng: 151.2195 },
    //    zoom: 13,
    //    mapTypeId: 'roadmap'
    //});

    //// Create the search box and link it to the UI element.
    //var input = document.getElementById('pac-input');
    //var searchBox = new google.maps.places.SearchBox(input);
    ////map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);

    //// Bias the SearchBox results towards current map's viewport.
    //map.addListener('bounds_changed', function () {
    //    searchBox.setBounds(map.getBounds());
    //});

    //var markers = [];
    //// Listen for the event fired when the user selects a prediction and retrieve
    //// more details for that place.
    //searchBox.addListener('places_changed', function () {
    //    var places = searchBox.getPlaces();

    //    console.log(places);

    //    if (places.length == 0) {
    //        return;
    //    }

    //    // Clear out the old markers.
    //    markers.forEach(function (marker) {
    //        marker.setMap(null);
    //    });
    //    markers = [];

    //    // For each place, get the icon, name and location.
    //    var bounds = new google.maps.LatLngBounds();
    //    places.forEach(function (place) {
    //        if (!place.geometry) {
    //            console.log("Returned place contains no geometry");
    //            return;
    //        }
    //        var icon = {
    //            url: place.icon,
    //            size: new google.maps.Size(71, 71),
    //            origin: new google.maps.Point(0, 0),
    //            anchor: new google.maps.Point(17, 34),
    //            scaledSize: new google.maps.Size(25, 25)
    //        };

    //        // Create a marker for each place.
    //        markers.push(new google.maps.Marker({
    //            map: map,
    //            icon: icon,
    //            title: place.name,
    //            position: place.geometry.location
    //        }));

    //        if (place.geometry.viewport) {
    //            // Only geocodes have viewport.
    //            bounds.union(place.geometry.viewport);
    //        } else {
    //            bounds.extend(place.geometry.location);
    //        }
    //    });
    //    map.fitBounds(bounds);
    //});

    var options = {
        types: ['(cities)']
    };

    var input = document.getElementById('pac-input');
    var autocomplete = new google.maps.places.Autocomplete(input, options);

    autocomplete.addListener('place_changed', function () {
        var place = autocomplete.getPlace();

        if (!place.geometry) {
            return;
        }

        var components = place.address_components;
        var city = 'n/a';
        var country = 'n/a';

        for (var c = 0; c < components.length; ++c) {

            if (components[c].types.indexOf('locality') > -1 && components[c].types.indexOf('political') > -1) {
                city = components[c].long_name;
            }

            if (components[c].types.indexOf('country') > -1 && components[c].types.indexOf('political') > -1) {
                country = components[c].long_name;
            }
        }

        document.getElementsByName("CityName")[0].value = city;
        document.getElementsByName("CountryName")[0].value = country;
        document.getElementsByName("Latitude")[0].value = place.geometry.location.lat();
        document.getElementsByName("Longitude")[0].value = place.geometry.location.lng();
        document.getElementsByName("GooglePlaceId")[0].value = place.place_id;
       
    });
}