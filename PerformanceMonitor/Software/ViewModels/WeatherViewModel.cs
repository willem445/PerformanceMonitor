using System;
using System.Xml;
using System.IO;
using System.Net;
using System.Timers;

namespace PerformanceMonitor
{
    internal class WeatherViewModel : IObserver<SettingsStruct>
    {
        //Fields*******************************************************************************
        private IDisposable unsubscriber;

        private WeatherModel _WeatherModel;
        Timer timer;
        private UInt32 wPoll = 30;
        private string apiKey = "1cca1919311be93d";
        private string state = "IL";
        private string town = "Chicago";

        //Constructor**************************************************************************
        public WeatherViewModel()
        {
            _WeatherModel = new WeatherModel();

            UpdateWeather();

            timer = new Timer(wPoll*60000);
            timer.Elapsed += new ElapsedEventHandler(UpdateWeather);
            timer.Enabled = true;
            timer.Start();
        }

        //Properties****************************************************************************
        public WeatherModel WeatherModel
        {
            get
            {
                return _WeatherModel;
            }
        }

        //Methods*******************************************************************************
        /// <summary>
        /// Get data from wunderground and assign to variables
        /// </summary>
        public void UpdateWeather(object source, ElapsedEventArgs e)
        {
            try
            {
                string input_xml = String.Format("http://api.wunderground.com/api/{0}/conditions/q/{1}/{2}.xml", apiKey, state, town);

                var cli = new WebClient();
                string weather = cli.DownloadString(input_xml);
                //Console.Write(weather);

                using (XmlReader reader = XmlReader.Create(new StringReader(weather)))
                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (reader.Name.Equals("full"))
                                {
                                    reader.Read();
                                    WeatherModel.Place = reader.Value;
                                }
                                else if (reader.Name.Equals("observation_time"))
                                {
                                    reader.Read();
                                    WeatherModel.ObsTime = reader.Value;
                                }
                                else if (reader.Name.Equals("weather"))
                                {
                                    reader.Read();
                                    WeatherModel.Weather = reader.Value;
                                }
                                else if (reader.Name.Equals("temp_f"))
                                {
                                    reader.Read();
                                    WeatherModel.Temperature = reader.Value + "°F";
                                }
                                else if (reader.Name.Equals("relative_humidity"))
                                {
                                    reader.Read();
                                    WeatherModel.Humidity = reader.Value;
                                }
                                else if (reader.Name.Equals("wind_mph"))
                                {
                                    reader.Read();
                                    WeatherModel.WindSpeed = reader.Value + " mph";
                                }
                                else if (reader.Name.Equals("pressure_mb"))
                                {
                                    reader.Read();
                                    WeatherModel.Pressure = reader.Value + " mb";
                                }
                                else if (reader.Name.Equals("dewpoint_f"))
                                {
                                    reader.Read();
                                    WeatherModel.Dewpoint = reader.Value + "°F";
                                }
                                else if (reader.Name.Equals("visibility_mi"))
                                {
                                    reader.Read();
                                    WeatherModel.Visibility = reader.Value + " mi";
                                }
                                else if (reader.Name.Equals("latitude"))
                                {
                                    reader.Read();
                                    WeatherModel.Latitude = reader.Value;
                                }
                                else if (reader.Name.Equals("longitude"))
                                {
                                    reader.Read();
                                    WeatherModel.Longitude = reader.Value;
                                }
                                else if (reader.Name.Equals("precip_today_in"))
                                {
                                    reader.Read();
                                    WeatherModel.Precipitation = reader.Value + "\"";
                                }
                                else if (reader.Name.Equals("feelslike_f"))
                                {
                                    reader.Read();
                                    WeatherModel.HeatIndex = reader.Value + "°F";
                                }

                                break;
                        }
                    }
            }
            catch (System.Net.WebException f)
            {
                Console.WriteLine("System.Net.WebException: {0}", f.Message);
            }
        }

        /// <summary>
        /// Get data from wunderground and assign to variables
        /// </summary>
        public void UpdateWeather()
        {
            try
            {
                string input_xml = String.Format("http://api.wunderground.com/api/{0}/conditions/q/{1}/{2}.xml", apiKey, state, town);

                var cli = new WebClient();
                string weather = cli.DownloadString(input_xml);
                //Console.Write(weather);

                using (XmlReader reader = XmlReader.Create(new StringReader(weather)))
                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (reader.Name.Equals("full"))
                                {
                                    reader.Read();
                                    WeatherModel.Place = reader.Value;
                                }
                                else if (reader.Name.Equals("observation_time"))
                                {
                                    reader.Read();
                                    WeatherModel.ObsTime = reader.Value;
                                }
                                else if (reader.Name.Equals("weather"))
                                {
                                    reader.Read();
                                    WeatherModel.Weather = reader.Value;
                                }
                                else if (reader.Name.Equals("temp_f"))
                                {
                                    reader.Read();
                                    WeatherModel.Temperature = reader.Value + "°F";
                                }
                                else if (reader.Name.Equals("relative_humidity"))
                                {
                                    reader.Read();
                                    WeatherModel.Humidity = reader.Value;
                                }
                                else if (reader.Name.Equals("wind_mph"))
                                {
                                    reader.Read();
                                    WeatherModel.WindSpeed = reader.Value + " mph";
                                }
                                else if (reader.Name.Equals("pressure_mb"))
                                {
                                    reader.Read();
                                    WeatherModel.Pressure = reader.Value + " mb";
                                }
                                else if (reader.Name.Equals("dewpoint_f"))
                                {
                                    reader.Read();
                                    WeatherModel.Dewpoint = reader.Value + "°F";
                                }
                                else if (reader.Name.Equals("visibility_mi"))
                                {
                                    reader.Read();
                                    WeatherModel.Visibility = reader.Value + " mi";
                                }
                                else if (reader.Name.Equals("latitude"))
                                {
                                    reader.Read();
                                    WeatherModel.Latitude = reader.Value;
                                }
                                else if (reader.Name.Equals("longitude"))
                                {
                                    reader.Read();
                                    WeatherModel.Longitude = reader.Value;
                                }
                                else if (reader.Name.Equals("precip_today_in"))
                                {
                                    reader.Read();
                                    WeatherModel.Precipitation = reader.Value + "\"";
                                }
                                else if (reader.Name.Equals("feelslike_f"))
                                {
                                    reader.Read();
                                    WeatherModel.HeatIndex = reader.Value + "°F";
                                }

                                break;
                        }
                    }
            }
            catch(System.Net.WebException e)
            {
                Console.WriteLine("System.Net.WebException: {0}", e.Message);
            }
        }

        //IObserver*****************************************************************************
        public virtual void Subscribe(IObservable<SettingsStruct> provider)
        {
            unsubscriber = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }

        public virtual void OnCompleted()
        {
            Console.WriteLine("Additional temperature data will not be transmitted.");
        }

        public virtual void OnError(Exception error)
        {
            // Do nothing.
        }

        public virtual void OnNext(SettingsStruct setting)
        {
            //Console.WriteLine("SettingsViewModel checking in.");
            //Console.WriteLine(setting.TempPoll);

            //Update timer interval (minutes * 60000 = ms)
            timer.Interval = setting.WeatherPoll * 60000;

            apiKey = setting.APIKey;
            state = setting.State;
            town = setting.Town;

            UpdateWeather();
        }
    }


    //Wunderground API reply example
    //        <response>
    //	<version>0.1</version>
    //	<termsofService>http://www.wunderground.com/weather/api/d/terms.html</termsofService>
    //	<features>
    //		<feature>conditions</feature>
    //	</features>
    //  <current_observation>
    //		<image>
    //		<url>http://icons.wxug.com/graphics/wu2/logo_130x80.png</url>
    //		<title>Weather Underground</title>
    //		<link>http://www.wunderground.com</link>
    //		</image>
    //		<display_location>
    //		<full>Leola, SD</full>
    //		<city>Leola</city>
    //		<state>SD</state>
    //		<state_name>South Dakota</state_name>
    //		<country>US</country>
    //		<country_iso3166>US</country_iso3166>
    //		<zip>57456</zip>
    //		<magic>1</magic>
    //		<wmo>99999</wmo>
    //		<latitude>45.72000122</latitude>
    //		<longitude>-98.94000244</longitude>
    //		<elevation>485.2</elevation>
    //		</display_location>
    //		<observation_location>
    //		<full>State line, Leola, South Dakota</full>
    //		<city>State line, Leola</city>
    //		<state>South Dakota</state>
    //		<country>US</country>
    //		<country_iso3166>US</country_iso3166>
    //		<latitude>45.923855</latitude>
    //		<longitude>-98.846153</longitude>
    //		<elevation>1614 ft</elevation>
    //		</observation_location>
    //		<estimated>
    //		</estimated>
    //		<station_id>KSDLEOLA2</station_id>
    //		<observation_time>Last Updated on July 17, 9:33 PM CDT</observation_time>
    //		<observation_time_rfc822>Mon, 17 Jul 2017 21:33:31 -0500</observation_time_rfc822>
    //		<observation_epoch>1500345211</observation_epoch>
    //		<local_time_rfc822>Mon, 17 Jul 2017 21:34:10 -0500</local_time_rfc822>
    //		<local_epoch>1500345250</local_epoch>
    //		<local_tz_short>CDT</local_tz_short>
    //		<local_tz_long>America/Chicago</local_tz_long>
    //		<local_tz_offset>-0500</local_tz_offset>
    //		<weather>Clear</weather>
    //		<temperature_string>79.1 F (26.2 C)</temperature_string>
    //		<temp_f>79.1</temp_f>
    //		<temp_c>26.2</temp_c>
    //		<relative_humidity>65%</relative_humidity>
    //		<wind_string>Calm</wind_string>
    //		<wind_dir>NW</wind_dir>
    //		<wind_degrees>315</wind_degrees>
    //		<wind_mph>0.0</wind_mph>
    //		<wind_gust_mph>0</wind_gust_mph>
    //		<wind_kph>0.0</wind_kph>
    //		<wind_gust_kph>0</wind_gust_kph>
    //		<pressure_mb>1008</pressure_mb>
    //		<pressure_in>29.77</pressure_in>
    //		<pressure_trend>+</pressure_trend>

    //		<dewpoint_string>66 F(19 C)</dewpoint_string>
    //		<dewpoint_f>66</dewpoint_f>
    //		<dewpoint_c>19</dewpoint_c>


    //		<heat_index_string>81 F(27 C)</heat_index_string>
    //		<heat_index_f>81</heat_index_f>
    //		<heat_index_c>27</heat_index_c>


    //		<windchill_string>NA</windchill_string>
    //		<windchill_f>NA</windchill_f>
    //		<windchill_c>NA</windchill_c>

    //        <feelslike_string>81 F(27 C)</feelslike_string>
    //        <feelslike_f>81</feelslike_f>
    //        <feelslike_c>27</feelslike_c>
    //		<visibility_mi>10.0</visibility_mi>
    //		<visibility_km>16.1</visibility_km>
    //		<solarradiation></solarradiation>
    //		<UV>0</UV>
    //		<precip_1hr_string>0.00 in ( 0 mm)</precip_1hr_string>
    //		<precip_1hr_in>0.00</precip_1hr_in>
    //		<precip_1hr_metric> 0</precip_1hr_metric>
    //		<precip_today_string>0.00 in (0 mm)</precip_today_string>
    //		<precip_today_in>0.00</precip_today_in>
    //		<precip_today_metric>0</precip_today_metric>



    //		<icon>clear</icon>
    //		<icon_url>http://icons.wxug.com/i/c/k/nt_clear.gif</icon_url>
    //		<forecast_url>http://www.wunderground.com/US/SD/Leola.html</forecast_url>

    //        <history_url>http://www.wunderground.com/weatherstation/WXDailyHistory.asp?ID=KSDLEOLA2</history_url>

    //		<ob_url>http://www.wunderground.com/cgi-bin/findweather/getForecast?query=45.923855,-98.846153</ob_url>
    //	</current_observation>
    //</response> 
}
