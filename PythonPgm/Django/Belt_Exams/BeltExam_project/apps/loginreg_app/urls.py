from django.conf.urls import url
from . import views

urlpatterns = [
	url(r'^$', views.index),
	url(r'^register$', views.registrationvalid),
	url(r'^login$', views.loginvalid),
	url(r'success$', views.success),
	url(r'logout$', views.logout),
	url(r'travel$', views.addtravel),
	url(r'trip$', views.triprecord),
	url(r'show/(?P<id>\d+)$', views.showtripinfo),
	url(r'add/(?P<id>\d+)$', views.addtrip)

]