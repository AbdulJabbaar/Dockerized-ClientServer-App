FROM python:3.6
RUN mkdir /ServerAppPython
WORKDIR "/ServerAppPython"
# Upgrade pip
RUN pip install --upgrade pip
# Update
RUN apt-get update \
    && apt-get clean; rm -rf /var/lib/apt/lists/* /tmp/* /var/tmp/* /usr/share/doc/*
ADD ServerAppPython/ServerAppPython.py /ServerAppPython/
CMD [ "python", "ServerAppPython.py" ]