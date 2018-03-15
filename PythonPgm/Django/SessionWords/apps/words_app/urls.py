from django.conf.urls import url
from . import views  
       
urlpatterns = [
	url(r'^$', views.index),
	url(r'word/process$', views.process),
	# url(r'result$', views.show),
	# url(r'back$', views.back)
   
]